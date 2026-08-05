using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Project : AccountOwnedEntity
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public DateOnly? Start { get; set; }
	public DateOnly? End { get; set; }
}
