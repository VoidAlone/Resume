using System.ComponentModel.DataAnnotations;

namespace Resume.Models.Identity;

public class Contact{
	public int Id {get;set;}
	public int UserId {get;set;}
	// public Identity.Profile Profile {get;set;} = null!;

	public string? FullName {get;set;}

	public string? Address{get;set;}

	[Phone]
	public string? Phone{get;set;}	

	[EmailAddress]
	public string? Email {get;set;}
}
