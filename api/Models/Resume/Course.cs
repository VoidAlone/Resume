using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

public class Course : ProfileOwnedEntity
{
	public int EducationId { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
