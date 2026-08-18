using System.Text.Json.Serialization;

namespace Resume.Models.ResumeModels;

public class UserOwnedEntity
{
	public int Id { get; set; }

	[JsonIgnore]
	public string UserId { get; set; } = null!;
}
