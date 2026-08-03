namespace Resume.Models.Resume;

public class Certificate : ProfileOwnedEntity {
	public string? Name {get;set;}
	public string? Organization {get;set;}
	public DateOnly Date {get;set;}
	public string? Description {get;set;}
}
