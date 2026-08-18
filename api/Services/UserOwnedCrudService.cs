using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models.ResumeModels;

namespace Resume.Services
{
	public class UserOwnedCrudService<T>(AppDbContext db) : ICrudService<T>
		where T : UserOwnedEntity
	{
		private readonly AppDbContext _db = db;

		public async Task<IReadOnlyCollection<T>> GetAllAsync(string userId, CancellationToken cancellationToken = default)
		{
			return await _db.Set<T>()
				.AsNoTracking()
				.Where(x => x.UserId == userId)
				.ToListAsync(cancellationToken);
		}

		public async Task<T?> GetByIdAsync(int id, string userId, CancellationToken cancellationToken = default)
		{
			return await _db.Set<T>()
				.AsNoTracking()
				.FirstOrDefaultAsync(
						x => x.UserId == userId && x.Id == id,
						cancellationToken);
		}

		public async Task<T> CreateAsync(T entity, string userId, CancellationToken cancellationToken = default)
		{
			entity.UserId = userId;

			_db.Set<T>().Add(entity);
			await _db.SaveChangesAsync(cancellationToken);

			return entity;
		}

		public async Task<T?> UpdateAsync(int id, T entity, string userId, CancellationToken cancellationToken = default)
		{
			var existing = await _db.Set<T>()
				.FirstOrDefaultAsync(
						x => x.UserId == userId && x.Id == id,
						cancellationToken);

			if (existing is null)
				return null;

			_db.Entry(existing)
				.CurrentValues
				.SetValues(entity);

			existing.Id = id;
			existing.UserId = userId;

			await _db.SaveChangesAsync(cancellationToken);

			return existing;
		}

		public async Task<bool> DeleteAsync(int id, string userId, CancellationToken cancellationToken = default)
		{
			var entity = await _db.Set<T>()
				.FirstOrDefaultAsync(
						x => x.UserId == userId && x.Id == id,
						cancellationToken);

			if (entity is null)
				return false;

			_db.Set<T>().Remove(entity);
			await _db.SaveChangesAsync(cancellationToken);

			return true;
		}
	}
}
