namespace Resume.Models.ResumeModels;

public class Course : UserOwnedEntity
{
	public int EducationId { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
