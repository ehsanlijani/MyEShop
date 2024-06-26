namespace MyEShop.Domain.IRepositories.Common;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    Task<bool> AddAsync(TEntity entity , CancellationToken cancellationToken);

    bool Update(TEntity entity);

    bool Delete(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}

