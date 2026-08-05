using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Education : AccountOwnedEntity
{
	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public ICollection<Course>? Courses {get;set;}
}

