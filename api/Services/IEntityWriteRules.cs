using Resume.Models.ResumeModels;

namespace Resume.Services
{
    public interface IEntityWriteRules<T> where T : UserOwnedEntity
    {
		Task<IDictionary<string, string[]>> ValidateAsync(
				T entity,
				string userId,
				CancellationToken cancellationToken
				);
    }
}
