namespace Resume.Models.ResumeModels;

public class Profile : UserOwnedEntity
{
	public string Name {get;set;} = null!;
	public string Desc {get;set;} = string.Empty; 
}

