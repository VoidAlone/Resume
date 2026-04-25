using System.ComponentModel.DataAnnotations;

namespace Resume.DTOs.Identity;

public record SocialDto{
	public int Id {get;set;}

	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}
}

// public record UpsertSocial{
// 	public string? Name {get;set;}
// 	public string? Display {get;set;}
//
// 	[Url]
// 	public string? Url {get;set;}
// }
