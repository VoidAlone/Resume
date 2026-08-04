using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Project : ProfileOwnedEntity{
	public string? Name {get;set;}
	public string? Description {get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
}
