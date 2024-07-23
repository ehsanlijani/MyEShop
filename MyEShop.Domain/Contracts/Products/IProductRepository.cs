using MyEShop.Domain.Contracts.Common;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Domain.Contracts.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetProductByIdAsync(long productId , CancellationToken cancellationToken);
}
