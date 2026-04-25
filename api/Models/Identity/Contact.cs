using System.ComponentModel.DataAnnotations;

namespace Resume.Models.Identity;

public class Contact{
	public int Id {get;set;}
	public int UserId {get;set;}
	public User User {get;set;} = null!;

	public string? Address{get;set;}

	[Phone]
	public string? Phone{get;set;}	

	[EmailAddress]
	public string? Email {get;set;}

	public List<Social>? Socials {get;set;}	
}
