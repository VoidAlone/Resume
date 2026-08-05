using System.Text.Json.Serialization;

namespace Resume.Models.Identity;

public class AccountOwnedEntity
{
	public int Id { get; set; }

	[JsonIgnore]
	public string AccountId { get; set; } = null!;
}
