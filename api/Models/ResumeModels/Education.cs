namespace Resume.Models.ResumeModels;

public class Education : UserOwnedEntity
{
	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public ICollection<Course>? Courses {get;set;}
}

