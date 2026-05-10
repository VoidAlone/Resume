using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models.Resume;

namespace Resume.Models.Identity;

public class Profile{
	public int Id {get;set;}
	public string Name {get;set;} = null!;
	public ICollection<Contact>? Contacts {get;set;}
	public List<Social>? Socials {get;set;}	
	public ICollection<Education>? Education {get;set;}
	public ICollection<Experience>? Experiences {get;set;}
	public ICollection<Project>? Projects {get;set;}
	public ICollection<Skill>? Skills {get;set;}
	public ICollection<Certificate>? Certificates {get;set;}
}

