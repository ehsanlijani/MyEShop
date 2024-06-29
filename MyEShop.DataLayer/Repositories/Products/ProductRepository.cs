using Microsoft.EntityFrameworkCore;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.DataLayer.Repositories.Products;

public class ProductRepository(MyEShopDbContext context)
    : GenericRepository<Product>(context), IProductRepository
{
    private readonly MyEShopDbContext _context = context;

    public async Task<Product> GetProductByIdAsync(long productId, CancellationToken cancellationToken)
        => await _context.Products.AsNoTracking().SingleOrDefaultAsync(product => product.Id == productId, cancellationToken).ConfigureAwait(false);

}
