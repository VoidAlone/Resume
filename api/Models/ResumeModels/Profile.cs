using System.Text.Json.Serialization;
using Resume.Models.Resume;

namespace Resume.Models.Identity;

public class Profile : AccountOwnedEntity
{
	public string Name {get;set;} = null!;
	public string Desc {get;set;} = string.Empty; 
}

