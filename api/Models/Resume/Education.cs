using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Education: IUserOwnedEntity{

	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public bool? Present {get;set;}

	[JsonIgnore]
	public ICollection<Course>? Courses {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
    // [JsonIgnore]
    // public ICollection<string>? Honors{get;set;}
}

