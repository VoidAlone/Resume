using System.ComponentModel.DataAnnotations;

namespace Resume.DTOs.Identity;

public record ReadSocialDto{
	public int Id {get;set;}

	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}
}
public record CreateSocialDto{
	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}
}
public record UpdateSocialDto{
	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}
}
