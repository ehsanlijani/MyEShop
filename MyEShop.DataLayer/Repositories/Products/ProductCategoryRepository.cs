using Microsoft.EntityFrameworkCore;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.DataLayer.Repositories.Products;

public class ProductCategoryRepository(MyEShopDbContext context)
    : GenericRepository<ProductCategory>(context), IProductCategoryRepository
{

    private readonly MyEShopDbContext _context = context;

    public async Task<bool> IsProductCategoryExistsByNameInUrl(string titleInUrl, CancellationToken cancellationToken)
        => await _context
            .ProductCategories.
            AnyAsync(category => category.TitleInUrl == titleInUrl, cancellationToken).ConfigureAwait(true);

    public async Task<ProductCategory> GetProductCategoryById(long categoryId , CancellationToken cancellationToken)
        => await _context.ProductCategories.SingleOrDefaultAsync(category => category.Id == categoryId , cancellationToken).ConfigureAwait(true);

}
