namespace Resume.Models.Resume;

public class Skill{
	public int Id {get;set;}
	public int UserId {get;set;}
	public Identity.User User {get;set;} = null!;

	public string? Name {get;set;}
	public string? Description {get;set;}
	public string? Proficiency {get;set;}
	public int? Years {get;set;}
	public SkillCategory? Category {get;set;}
}
