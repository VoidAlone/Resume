using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Resume.Models.ResumeModels;

namespace Resume.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
	public DbSet<Profile> Profiles => Set<Profile>();
	public DbSet<Contact> Contacts => Set<Contact>();
	public DbSet<Social> Socials => Set<Social>();
	public DbSet<Education> Education => Set<Education>();
	public DbSet<Course> Courses => Set<Course>();
	public DbSet<Experience> Experiences => Set<Experience>();
	public DbSet<Project> Projects => Set<Project>();
	public DbSet<Skill> Skills => Set<Skill>();
	public DbSet<Certificate> Certificates => Set<Certificate>();
}
