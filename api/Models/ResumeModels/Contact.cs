using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Resume.Models;
using Resume.Models.Identity;

namespace Resume.Models.Resume;

public class Contact : AccountOwnedEntity
{
	[Phone]
	public string? Phone { get; set; }
	[EmailAddress]
	public string? Email { get; set; }
	public string? FullName { get; set; }
	public string? Address { get; set; }
}
