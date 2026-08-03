namespace Resume.DTOs.Identity;

public record ReadAccountDto{
	public string? Id {get;set;}
	public string? UserName{get;set;}
	public string? Email{get;set;}
}

public record CreateAccountDto{
	public string? UserName {get;set;}
}

public record UpdateAccountDto{
	public string? UserName {get;set;}
}
