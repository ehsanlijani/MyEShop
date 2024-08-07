﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyEShop.Domain.Contracts.Common;
using MyEShop.Infrastructure.Persistence.Context;

namespace MyEShop.Infrastructure.Persistence.Repositories.Common;

public class GenericRepository<TEntity>(MyEShopDbContext dbContext) : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);

    public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        EntityEntry result = await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(true);
        return result.State == EntityState.Added;
    }

    public bool Update(TEntity entity)
    {
        EntityEntry result = _dbSet.Update(entity);
        return result.State == EntityState.Modified;
    }

    public bool Delete(TEntity entity)
    {
        EntityEntry result = _dbSet.Remove(entity);
        return result.State == EntityState.Deleted;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

}

