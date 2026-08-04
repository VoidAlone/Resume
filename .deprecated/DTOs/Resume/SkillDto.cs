using Resume.Models.Resume;

namespace Resume.DTOs.Resume;

public record SkillDto{
	public int Id {get;set;}

	public string? Name {get;set;}
	public string? Description {get;set;}
	public string? Proficiency {get;set;}
	public int? Years {get;set;}
	public SkillCategory? Category {get;set;}
}

// public record UpsertSkill{
// 	public string? Name {get;set;}
// 	public string? Description {get;set;}
// 	public string? Proficiency {get;set;}
// 	public int? Years {get;set;}
// 	public SkillCategory? Category {get;set;}
// }
//
