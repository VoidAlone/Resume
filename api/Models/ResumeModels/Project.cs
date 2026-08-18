namespace Resume.Models.ResumeModels;

public class Project : UserOwnedEntity
{
	public string? Name { get; set; }
	public string? Description { get; set; }
	public DateOnly? Start { get; set; }
	public DateOnly? End { get; set; }
}
