using System.ComponentModel.DataAnnotations;

namespace Resume.DTOs.Identity;

public record ReadContactDto{
	public int Id {get;set;}

	public string? Address{get;set;}

	[Phone]
	public string? Phone{get;set;}	

	[EmailAddress]
	public string? Email {get;set;}
}

// public record UpsertContact{
// 	public string? Address{get;set;}
//
// 	[Phone]
// 	public string? Phone{get;set;}	
//
// 	[EmailAddress]
// 	public string? Email {get;set;}
// }
