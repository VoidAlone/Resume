namespace Resume.DTOs.Resume;

public record ProjectDto{
	public int Id{get;set;}
	
	public string? Name {get;set;}
	public string? Description {get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}
}

// public record UpsertProject{
// 	public string? Name {get;set;}
// 	public string? Description {get;set;}
// 	public DateOnly? Start {get;set;}
// 	public DateOnly? End {get;set;}
// 	public bool? Present {get;set;}
// }
