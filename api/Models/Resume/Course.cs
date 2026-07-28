using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Course: IUserOwnedEntity{
	// public Identity.Profile Profile{get;set;} = null!;

	public int EducationId {get; private set;}
	[JsonIgnore]
	public Education Education {get; private set;} = null!;

	public string? Name {get;set;}
	public string? Description {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
}
