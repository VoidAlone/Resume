using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Endpoints;
using Resume.Models.ResumeModels;
using Resume.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseSqlite(
			builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
	.AddIdentityApiEndpoints<User>()
	.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped(
		typeof(ICrudService<>),
		typeof(UserOwnedCrudService<>));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapGroup("/api/auth")
	.MapIdentityApi<User>();
app.MapUserCrudRoutes();

// Seed
using (var scope = app.Services.CreateScope()){
	var services = scope.ServiceProvider;
	SeedUsers.Initialize(services);
}

app.Run();

