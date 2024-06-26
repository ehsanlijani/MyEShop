using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Common;

namespace MyEShop.Domain.IRepositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetProductByIdAsync(long productId , CancellationToken cancellationToken);
}
