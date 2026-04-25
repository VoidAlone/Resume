namespace Resume.Models.Resume;

public class Project{
	public int Id{get;set;}
	public int UserId{get;set;}
	public Identity.User User {get;set;} = null!;
	
	public string? Name {get;set;}
	public string? Description {get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
}
