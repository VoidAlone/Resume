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
			// Identity fields belong to the server, even when supplied in the request.
			entity.Id = 0;
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

			// Normalize identity before copying values: EF cannot change a tracked primary key.
			entity.Id = existing.Id;
			entity.UserId = existing.UserId;

			// PUT replaces scalar values; navigation collections are not updated here.
			_db.Entry(existing)
				.CurrentValues
				.SetValues(entity);


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
