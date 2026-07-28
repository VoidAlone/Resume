using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Resume.Models.Identity;

public class Social : IUserOwnedEntity{
	
	public int ProfileId {get; private set;}

	[JsonIgnore]
	public Profile Profile {get;set;} = null!;

	public string? Name {get;set;}
	public string? Display {get;set;}

	[Url]
	public string? Url {get;set;}

    string IUserOwnedEntity.Id => ((IUserOwnedEntity)Profile).Id;

    string IUserOwnedEntity.UserId => ((IUserOwnedEntity)Profile).UserId;
}
