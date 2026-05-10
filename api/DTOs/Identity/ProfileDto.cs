namespace Resume.DTOs.Identity;

public class ReadProfileDto{
	public int Id {get;set;}
	public string? Name {get;set;}
}

public class CreateProfileDto{
	public string Name {get;set;} = null!;
}
public class UpdateProfileDto{
	public string Name {get;set;} = null!;
}

