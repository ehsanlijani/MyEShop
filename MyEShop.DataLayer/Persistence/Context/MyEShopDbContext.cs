using Microsoft.EntityFrameworkCore;
using MyEShop.Domain.Contracts.Common;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.Entities.Users;
using MyEShop.Infrastructure.Extensions;
using System.Reflection;

namespace MyEShop.Infrastructure.Persistence.Context;

public class MyEShopDbContext(DbContextOptions<MyEShopDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       // builder.RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly);

        base.OnModelCreating(builder);
    }
}




