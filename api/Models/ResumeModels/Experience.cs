namespace Resume.Models.ResumeModels;

public class Experience : UserOwnedEntity
{
	public string? Organization { get; set; }
	public string? Description { get; set; }
	public string? Title { get; set; }
	public DateOnly? Start { get; set; }
	public DateOnly? End { get; set; }
}
