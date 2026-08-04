namespace Resume.DTOs.Resume;

public record CertificateDto{
	public int Id {get;set;}

	public string? Name {get;set;}
	public string? Organization {get;set;}
	public DateOnly Date {get;set;}
	public string? Description {get;set;}
}

// public record UpsertCertificate{
// 	public string? Name {get;set;}
// 	public string? Organization {get;set;}
// 	public DateOnly Date {get;set;}
// 	public string? Description {get;set;}
// }
