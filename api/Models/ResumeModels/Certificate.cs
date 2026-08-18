namespace Resume.Models.ResumeModels;

public class Certificate : UserOwnedEntity
{
	public string? Name { get; set; }
	public string? Organization { get; set; }
	public DateOnly Date { get; set; }
	public string? Description { get; set; }
}
