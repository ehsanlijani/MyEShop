using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Common;

namespace MyEShop.Domain.IRepositories.Products;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
{
    Task<bool> IsProductCategoryExistsByNameInUrl(string titleInUrl , CancellationToken cancellationToken);
    Task<ProductCategory> GetProductCategoryById(long categoryId , CancellationToken cancellationToken);
}
