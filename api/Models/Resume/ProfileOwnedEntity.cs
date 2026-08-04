using System.Text.Json.Serialization;

namespace Resume.Models.Resume;

abstract public class ProfileOwnedEntity{

	public int Id {get;set;} 

	[JsonIgnore]
	public int ProfileId{get;set;} 

}
