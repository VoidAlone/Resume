using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Resume.Models;

namespace Resume.Models.Resume;

public class Contact : ProfileOwnedEntity
{
	[Phone]
	public string? Phone { get; set; }
	[EmailAddress]
	public string? Email { get; set; }
	public string? FullName { get; set; }
	public string? Address { get; set; }
}
