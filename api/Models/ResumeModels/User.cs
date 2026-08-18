using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resume.Data;

namespace Resume.Models.ResumeModels;

public class User : IdentityUser
{
}

public static class SeedUsers
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (context == null || context.Users == null)
        {
            throw new ArgumentNullException("Null Resume Context");
        }
        if (context.Users.Any())
        {
            return;
        }
        context.Users.AddRange(
                new User
                {
                    UserName = "WetNapkin123",
                },
                new User
                {
                    UserName = "ToeJam82",
                }
                );
        context.SaveChanges();
    }
}
