namespace Resume.DTOs.Resume;

public record EducationDto{
	public int Id {get;set;}

	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
	public ICollection<string>? Honors{get;set;}
}

// public record UpsertEducation{
// 	public string? Organization {get;set;}
// 	public float? Gpa{get;set;}
// 	public DateOnly? Start {get;set;}
// 	public DateOnly? End {get;set;}
// 	public bool? Present {get;set;}
// 	public ICollection<string>? Honors{get;set;}
// }
//
