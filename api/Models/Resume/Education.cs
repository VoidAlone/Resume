namespace Resume.Models.Resume;

public class Education : ProfileOwnedEntity {
	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public ICollection<Course>? Courses {get;set;}
	public ICollection<string>? Honors{get;set;}
}

