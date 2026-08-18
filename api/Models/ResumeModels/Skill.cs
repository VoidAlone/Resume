namespace Resume.Models.ResumeModels;

public class Skill : UserOwnedEntity
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public string? Proficiency { get; set; }
	public int? Years { get; set; }
	public SkillCategory? Category { get; set; }
}
