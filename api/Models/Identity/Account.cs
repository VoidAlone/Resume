using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resume.Data;

namespace Resume.Models.Identity;

public class Account : IdentityUser {
	public Profile? UserProfile {get;set;}
}

public static class SeedAccounts{
	public static void Initialize(IServiceProvider serviceProvider){
		using (var context = new AppDbContext(
					serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()
					)){
			if(context == null || context.Accounts == null){
				throw new ArgumentNullException("Null Resume Context");
			}
			if(context.Accounts.Any()){
				return;
			}
			context.Accounts.AddRange(
					new Account{
						UserName = "WetNapkin123",
					},
					new Account{
						UserName = "ToeJam82",
					}
					);
			context.SaveChanges();
		}
	}
}
