using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Skill : AccountOwnedEntity
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public string? Proficiency { get; set; }
	public int? Years { get; set; }
	public SkillCategory? Category { get; set; }
}
