using System.ComponentModel.DataAnnotations;

namespace Resume.Models.Identity;

public class Contact{
	public int Id {get;set;}
	public int UserId {get;set;}
	public Profile Profile {get;set;} = null!;

	public string? FullName {get;set;}

	public string? Address{get;set;}

	[Phone]
	public List<string>? Phone{get;set;}	

	[EmailAddress]
	public List<string>? Email {get;set;}

	public List<Social>? Socials {get;set;}	
}
