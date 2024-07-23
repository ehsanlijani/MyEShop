using MyEShop.Domain.Entities.Products;
using MyEShop.Infrastructure.Persistence.Context;

namespace MyEShop.Infrastructure.Persistence.Seeder;

public class ProductSeeder
{
    public static void SeedData(MyEShopDbContext context)
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "test1", Price = 180000, ProductCategoryId = 2 , Quantity = 10 , Description = "this is description" , ShortDescription = "this is short description"},
                new Product { Name = "test2", Price = 180000, ProductCategoryId = 2 , Quantity = 2 , Description = "this is description2" , ShortDescription = "this is short description2"}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
