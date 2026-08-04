using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Education : ProfileOwnedEntity {
	public string? Organization {get;set;}
	public float? Gpa{get;set;}
	public DateOnly? Start {get;set;}
	public DateOnly? End {get;set;}
	public ICollection<Course>? Courses {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();
    // [JsonIgnore]
    // public ICollection<string>? Honors{get;set;}
}

