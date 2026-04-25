namespace Resume.Models.Resume;

public class Education{
	public int Id {get;set;}
	public int UserId {get;set;}
	public Identity.User User {get;set;} = null!;

	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
	public ICollection<Course>? Courses {get;set;}
	public ICollection<string>? Honors{get;set;}
}

