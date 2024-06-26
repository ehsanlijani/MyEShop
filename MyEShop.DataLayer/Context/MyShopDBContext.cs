using Microsoft.EntityFrameworkCore;
using MyEShop.Domain.Entities.Products;
using MyEShop.Domain.Entities.Users;
using System.Reflection;

namespace MyEShop.DataLayer.Context;

public class MyShopDbContext(DbContextOptions<MyShopDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}




