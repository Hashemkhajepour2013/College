using College.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace College.Data.Repositories.Contracts;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);

    void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);

    Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
}