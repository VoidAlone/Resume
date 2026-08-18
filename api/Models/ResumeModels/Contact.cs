using System.ComponentModel.DataAnnotations;

namespace Resume.Models.ResumeModels;

public class Contact : UserOwnedEntity
{
	[Phone]
	public string? Phone { get; set; }
	[EmailAddress]
	public string? Email { get; set; }
	public string? FullName { get; set; }
	public string? Address { get; set; }
}
