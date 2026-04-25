using System.ComponentModel.DataAnnotations;

namespace Resume.Models.Identity;

public class Social{
	public int Id {get;set;}
	public int UserId {get;set;}
	public User User {get;set;} = null!;

	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}
}
