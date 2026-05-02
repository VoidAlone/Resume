namespace Resume.Models.Resume;

public class Experience{
	public int Id{get;set;}
	public int UserId {get;set;}
	public Identity.Profile Profile{get;set;} = null!;

	public string? Organization{get;set;}
	public string? Description{get;set;}
	public string? Title{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
}
