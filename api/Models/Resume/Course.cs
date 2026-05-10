namespace Resume.Models.Resume;

public class Course{
	public int Id {get;set;}
	public int UserId {get;set;}
	// public Identity.Profile Profile{get;set;} = null!;

	public string? Name {get;set;}
	public string? Description {get;set;}
}
