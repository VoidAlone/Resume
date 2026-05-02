namespace Resume.Models.Resume;

public class Certificate{
	public int Id {get;set;}
	public int UserId {get;set;}
	public Identity.Profile Profile {get;set;} = null!;

	public string? Name {get;set;}
	public string? Organization {get;set;}
	public DateOnly Date {get;set;}
	public string? Description {get;set;}
}
