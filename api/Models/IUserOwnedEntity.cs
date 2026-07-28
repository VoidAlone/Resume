namespace Resume.Models
{
	public interface IUserOwnedEntity
	{
		public string Id { get; }
		public string UserId { get; }
	}
}
