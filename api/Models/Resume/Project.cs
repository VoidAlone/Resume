using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Project: IUserOwnedEntity{

	public int EducationId {get; private set;}
	[JsonIgnore]
	public Education Education {get; private set;} = null!;
	
	public string? Name {get;set;}
	public string? Description {get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
}
