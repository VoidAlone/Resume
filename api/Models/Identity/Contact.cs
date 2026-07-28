using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Resume.Models.Identity;

public class Contact : IUserOwnedEntity {

	public int ProfileId {get; private set;}

	[JsonIgnore]
	public Profile Profile {get;set;} = null!;

	public string? FullName {get;set;}

	public string? Address{get;set;}

	[Phone]
	public string? Phone{get;set;}	

	[EmailAddress]
	public string? Email {get;set;}

    string IUserOwnedEntity.Id => throw new NotImplementedException();

    string IUserOwnedEntity.UserId => throw new NotImplementedException();

}
