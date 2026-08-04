namespace Resume.DTOs.Resume;

public record ExperienceDto{
	public int Id{get;set;}

	public string? Organization{get;set;}
	public string? Description{get;set;}
	public string? Title{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
}

// public record UpsertExperience{
// 	public string? Organization{get;set;}
// 	public string? Description{get;set;}
// 	public string? Title{get;set;}
// 	public DateOnly? Start {get;set;}
// 	public DateOnly? End {get;set;}
// 	public bool? Present {get;set;}
// }
