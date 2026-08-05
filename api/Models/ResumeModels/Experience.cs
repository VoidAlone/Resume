using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Experience : AccountOwnedEntity
{
	public string? Organization { get; set; }
	public string? Description { get; set; }
	public string? Title { get; set; }
	public DateOnly? Start { get; set; }
	public DateOnly? End { get; set; }
}
