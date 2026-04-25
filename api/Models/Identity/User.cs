using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models.Resume;

namespace Resume.Models.Identity;

public class User{
	public int Id {get;set;}
	public string? Name {get;set;}
	public Contact? Contact {get;set;}
	public ICollection<Education>? Education {get;set;}
	public ICollection<Experience>? Experiences {get;set;}
	public ICollection<Project>? Projects {get;set;}
	public ICollection<Skill>? Skills {get;set;}
	public ICollection<Certificate>? Certificates {get;set;}
}

public static class SeedUser{
	public static void Initialize(IServiceProvider serviceProvider){
		using (var context = new AppDbContext(
					serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()
					)){
			if(context == null || context.Users == null){
				throw new ArgumentNullException("Null Resume Context");
			}
			if(context.Users.Any()){
				return;
			}
			context.Users.AddRange(
					new User{
						Name = "John",
					},
					new User{
						Name = "Jane",
					}
					);
			context.SaveChanges();
		}
	}
}
