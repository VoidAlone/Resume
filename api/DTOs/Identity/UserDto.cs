namespace Resume.DTOs.Identity;

public record ReadUserDto{
	public int Id {get;set;}
	public string? Name {get;set;}
}

public record CreateUserDto{
	public string? Name {get;set;}
}

public record UpdateUserDto{
	public string? Name {get;set;}
}
