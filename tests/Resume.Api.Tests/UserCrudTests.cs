using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resume.Data;
using Resume.Endpoints;
using Resume.Models.ResumeModels;
using Resume.Services;

namespace Resume.Api.Tests;

// Real routes and persistence, with a test-only identity supplied by a header.
// This exercises CRUD independently of registration, login, and startup seeding.
public class UserCrudTests : IAsyncLifetime
{
    private readonly string _databasePath = Path.Combine(Path.GetTempPath(), $"resume-crud-{Guid.NewGuid()}.db");
    private WebApplication _app = null!;
    private HttpClient _client = null!;

    public async Task InitializeAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={_databasePath};Pooling=False"));
        builder.Services.AddScoped(typeof(ICrudService<>), typeof(UserOwnedCrudService<>));
        builder.Services.AddAuthentication("Test")
            .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("Test", _ => { });
        builder.Services.AddAuthorization();

        _app = builder.Build();
        _app.UseAuthentication();
        _app.UseAuthorization();
        _app.MapUserCrudRoutes();
        using (var scope = _app.Services.CreateScope())
        {
            await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreatedAsync();
        }
        await _app.StartAsync();
        _client = _app.GetTestClient();
        _client.DefaultRequestHeaders.Add("X-Test-User", "alice");
    }

    [Fact]
    public async Task Create_returns_saved_entity_and_followable_location()
    {
        var response = await _client.PostAsJsonAsync("/api/skills/", new { id = 9000, name = "C#", userId = "bob" });
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var created = (await response.Content.ReadFromJsonAsync<Skill>())!;
        Assert.True(created.Id > 0);
        Assert.NotEqual(9000, created.Id);
        Assert.Equal("C#", created.Name);
        Assert.NotNull(response.Headers.Location);
        Assert.EndsWith($"/api/skills/{created.Id}", response.Headers.Location.ToString());

        var fetched = await _client.GetFromJsonAsync<Skill>(response.Headers.Location);
        Assert.Equal(created.Id, fetched!.Id);
        Assert.Equal("C#", fetched.Name);
        var saved = await ReadSkillAsync(created.Id);
        Assert.Equal("alice", saved.UserId);
        Assert.Equal("C#", saved.Name);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Update_uses_route_id_and_replaces_scalar_values(bool conflictingBodyId)
    {
        var id = await SeedSkillAsync("alice");
        object body = conflictingBodyId
            ? new { id = id + 100, name = "Updated", userId = "bob" }
            : new { name = "Updated", userId = "bob" };
        var response = await _client.PutAsJsonAsync($"/api/skills/{id}", body);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var updated = (await response.Content.ReadFromJsonAsync<Skill>())!;
        Assert.Equal(id, updated.Id);
        Assert.Equal("Updated", updated.Name);
        var saved = await ReadSkillAsync(id);
        Assert.Equal("Updated", saved.Name);
        Assert.Equal("alice", saved.UserId);
        Assert.Null(saved.Description); // Omitted scalar fields are replaced, not patched.
    }

    [Fact]
    public async Task Update_missing_record_returns_not_found()
    {
        var response = await _client.PutAsJsonAsync("/api/skills/999", new { name = "Updated" });
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Update_another_users_record_returns_not_found_and_preserves_it()
    {
        var id = await SeedSkillAsync("bob");
        var response = await _client.PutAsJsonAsync($"/api/skills/{id}", new { name = "Changed" });
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        var saved = await ReadSkillAsync(id);
        Assert.Equal("Original", saved.Name);
        Assert.Equal("bob", saved.UserId);
        Assert.Equal("Original description", saved.Description);
    }

    [Fact]
    public async Task Anonymous_create_is_rejected()
    {
        _client.DefaultRequestHeaders.Remove("X-Test-User");
        var response = await _client.PostAsJsonAsync("/api/skills/", new { name = "C#" });
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    private async Task<int> SeedSkillAsync(string owner)
    {
        using var scope = _app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var skill = new Skill { Name = "Original", Description = "Original description", UserId = owner };
        db.Skills.Add(skill);
        await db.SaveChangesAsync();
        return skill.Id;
    }

    // Every assertion reads through a fresh context so tracked objects cannot hide failed saves.
    private async Task<Skill> ReadSkillAsync(int id)
    {
        using var scope = _app.Services.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<AppDbContext>()
            .Skills.AsNoTracking().SingleAsync(x => x.Id == id);
    }

    public async Task DisposeAsync()
    {
        _client.Dispose();
        await _app.DisposeAsync();
        File.Delete(_databasePath);
    }

    private sealed class TestAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var userId = Request.Headers["X-Test-User"].ToString();
            if (string.IsNullOrEmpty(userId))
                return Task.FromResult(AuthenticateResult.NoResult());
            var identity = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, userId)], Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(
                new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name)));
        }
    }
}
