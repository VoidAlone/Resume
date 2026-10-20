using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models.ResumeModels;

namespace Resume.Services
{
    public class CourseWriteRules<T>(AppDbContext db) : IEntityWriteRules<T>
        where T : UserOwnedEntity
    {
        public Task<IDictionary<string, string[]>> ValidateAsync(T entity, string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
