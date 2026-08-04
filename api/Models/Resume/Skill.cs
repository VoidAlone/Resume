using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Skill : ProfileOwnedEntity{
	public string? Name {get;set;}
	public string? Description {get;set;}
	public string? Proficiency {get;set;}
	public int? Years {get;set;}
	public SkillCategory? Category {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
}
