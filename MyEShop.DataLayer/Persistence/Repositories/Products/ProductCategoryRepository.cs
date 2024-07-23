using Microsoft.EntityFrameworkCore;
using MyEShop.Domain.Contracts.Products;
using MyEShop.Domain.Entities.Products;
using MyEShop.Infrastructure.Persistence.Context;
using MyEShop.Infrastructure.Persistence.Repositories.Common;

namespace MyEShop.Infrastructure.Persistence.Repositories.Products;

public class ProductCategoryRepository(MyEShopDbContext context)
    : GenericRepository<ProductCategory>(context), IProductCategoryRepository
{

    private readonly MyEShopDbContext _context = context;

    public async Task<bool> IsProductCategoryExistsByNameInUrl(string titleInUrl, CancellationToken cancellationToken)
        => await _context
            .ProductCategories.AsNoTracking().
            AnyAsync(category => category.TitleInUrl == titleInUrl, cancellationToken).ConfigureAwait(false);

    public async Task<ProductCategory> GetProductCategoryById(long categoryId, CancellationToken cancellationToken)
        => await _context.ProductCategories.AsNoTracking().SingleOrDefaultAsync(category => category.Id == categoryId, cancellationToken).ConfigureAwait(false);

}
