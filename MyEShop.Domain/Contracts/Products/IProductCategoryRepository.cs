using MyEShop.Domain.Contracts.Common;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Domain.Contracts.Products;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
{
    Task<bool> IsProductCategoryExistsByNameInUrl(string titleInUrl , CancellationToken cancellationToken);
    Task<ProductCategory> GetProductCategoryById(long categoryId , CancellationToken cancellationToken);
}
