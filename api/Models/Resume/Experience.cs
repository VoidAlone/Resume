namespace Resume.Models.Resume;

public class Experience : ProfileOwnedEntity{
	public string? Organization{get;set;}
	public string? Description{get;set;}
	public string? Title{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
}
