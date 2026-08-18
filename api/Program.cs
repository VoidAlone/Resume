using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models.ResumeModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddControllers();

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthorization();

var app = builder.Build();

// app.MapControllers();

using (var scope = app.Services.CreateScope()){
	var services = scope.ServiceProvider;
	SeedUsers.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();

app.Run();

