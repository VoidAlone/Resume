using System.ComponentModel.DataAnnotations;

namespace Resume.Models.ResumeModels;

public class Social : UserOwnedEntity
{
	[Url]
	public string? Url {get;set;}
	public string? Name {get;set;}
	public string? Display {get;set;}
}
