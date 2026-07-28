using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Skill: IUserOwnedEntity{

	public int EducationId {get; private set;}
	[JsonIgnore]
	public Education Education {get; private set;} = null!;

	public string? Name {get;set;}
	public string? Description {get;set;}
	public string? Proficiency {get;set;}
	public int? Years {get;set;}
	public SkillCategory? Category {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
}
