using Resume.Models.Identity;
using Resume.Models.Resume;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Resume.Data;

public class AppDbContext : IdentityDbContext<Account>{

	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<Account> Accounts => Set<Account>();
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
