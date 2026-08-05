using System.Text.Json.Serialization;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Certificate : AccountOwnedEntity
{
	public string? Name { get; set; }
	public string? Organization { get; set; }
	public DateOnly Date { get; set; }
	public string? Description { get; set; }
}
