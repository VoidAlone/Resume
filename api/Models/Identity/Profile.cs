using System.Text.Json.Serialization;
using Resume.Models.Resume;

namespace Resume.Models.Identity;

public class Profile : IUserOwnedEntity{
	public string Name {get;set;} = null!;

	[JsonIgnore]
	public ICollection<Contact>? Contacts {get;set;}
	[JsonIgnore]
	public List<Social>? Socials {get;set;}	
	[JsonIgnore]
	public ICollection<Education>? Education {get;set;}
	[JsonIgnore]
	public ICollection<Experience>? Experiences {get;set;}
	[JsonIgnore]
	public ICollection<Project>? Projects {get;set;}
	[JsonIgnore]
	public ICollection<Skill>? Skills {get;set;}
	[JsonIgnore]
	public ICollection<Certificate>? Certificates {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
}

