﻿using College.Common.Utilities;
using College.Data.Repositories.Contracts;
using College.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace College.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly ApplicationDbContext DbContext;
    public DbSet<TEntity> Entities { get; }
    public virtual IQueryable<TEntity> Table => Entities;
    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = DbContext.Set<TEntity>(); // City => Cities
    }

    public virtual async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return await Entities.FindAsync(ids, cancellationToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Update(entity);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.UpdateRange(entities);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Remove(entity);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
        bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.RemoveRange(entities);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.AddRange(entities);
        if (saveNow)
            DbContext.SaveChanges();
    }
}