using System.ComponentModel.DataAnnotations;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Social : AccountOwnedEntity
{
	[Url]
	public string? Url {get;set;}
	public string? Name {get;set;}
	public string? Display {get;set;}
}
