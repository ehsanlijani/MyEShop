using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyEShop.DataLayer.Context;
using MyEShop.DataLayer.Repositories.Common;
using MyEShop.DataLayer.Repositories.Products;
using MyEShop.DataLayer.Repositories.Users;
using MyEShop.Domain.IRepositories.Common;
using MyEShop.Domain.IRepositories.Products;
using MyEShop.Domain.IRepositories.Users;

namespace MyEShop.DataLayer;

public static class DataLayerConfigs
{
    public static IServiceCollection RegisterDataLayerConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context

        services.AddDbContext<MyShopDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MyShopDbContext"));
        });

        #endregion

        #region Repositories

        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        #endregion

        return services;
    }
}