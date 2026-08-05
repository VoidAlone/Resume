using Resume.Models;
using Resume.Models.Identity;
using Resume.Models.Resume;

namespace Resume.Services;

public interface ICrudService<TEntity>
	where TEntity : AccountOwnedEntity
{
	//getall
	Task<IReadOnlyCollection<TEntity>> GetAllAsync(
			string AccountId,
			CancellationToken cancellationToken = default
	);
	//get
	Task<TEntity?> GetByIdAsync(
			int id,
			string AccountId,
			CancellationToken cancellationToken = default
			);
	//create
	Task<TEntity> CreateAsync(
			TEntity entity,
			string AccountId,
			CancellationToken cancellationToken = default
			);
	//update
	Task<TEntity?> UpdateAsync(
			int id,
			TEntity entity,
			string AccountId,
			CancellationToken cancellationToken = default
			);
	//delete
	Task<bool> DeleteAsync(
			int id,
			string AccountId,
			CancellationToken cancellationToken = default
			);
}
