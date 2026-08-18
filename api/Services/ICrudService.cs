using Resume.Models.ResumeModels;

namespace Resume.Services;

public interface ICrudService<TEntity>
	where TEntity : UserOwnedEntity
{
	//getall
	Task<IReadOnlyCollection<TEntity>> GetAllAsync(
			string userId,
			CancellationToken cancellationToken = default
	);
	//get
	Task<TEntity?> GetByIdAsync(
			int id,
			string userId,
			CancellationToken cancellationToken = default
			);
	//create
	Task<TEntity> CreateAsync(
			TEntity entity,
			string userId,
			CancellationToken cancellationToken = default
			);
	//update
	Task<TEntity?> UpdateAsync(
			int id,
			TEntity entity,
			string userId,
			CancellationToken cancellationToken = default
			);
	//delete
	Task<bool> DeleteAsync(
			int id,
			string userId,
			CancellationToken cancellationToken = default
			);
}
