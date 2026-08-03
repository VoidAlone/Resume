using System.ComponentModel.DataAnnotations;

namespace Resume.Models.Resume;

public class Social : ProfileOwnedEntity
{
	[Url]
	public string? Url {get;set;}
	public string? Name {get;set;}
	public string? Display {get;set;}
}
