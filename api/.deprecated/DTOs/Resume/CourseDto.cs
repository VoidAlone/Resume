namespace Resume.DTOs.Resume;

public record CourseDto{
	public int Id {get;set;}

	public string? Name {get;set;}
	public string? Description {get;set;}
}
// public record UpsertCourse{
// 	public string? Name {get;set;}
// 	public string? Description {get;set;}
// }
