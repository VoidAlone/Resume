using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Course : AccountOwnedEntity
{
	public int EducationId { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
