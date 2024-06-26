using Microsoft.EntityFrameworkCore;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.IRepositories.Products;

namespace MyEShop.DataLayer.Repositories.Products;

public class ProductRepository(MyShopDbContext context)
    : GenericRepository<Product>(context), IProductRepository
{
    private readonly MyShopDbContext _context = context;

    public async Task<Product> GetProductByIdAsync(long productId , CancellationToken cancellationToken)
        => await _context.Products.SingleOrDefaultAsync(product => product.Id == productId , cancellationToken).ConfigureAwait(true);

}
