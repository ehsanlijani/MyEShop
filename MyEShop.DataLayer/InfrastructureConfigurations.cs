using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyEShop.Domain.IRepositories.Common;
using MyEShop.Domain.IRepositories.Products;
using MyEShop.Domain.IRepositories.Users;
using MyEShop.Infrastructure.Persistence.Context;
using MyEShop.Infrastructure.Persistence.Repositories.Common;
using MyEShop.Infrastructure.Persistence.Repositories.Products;
using MyEShop.Infrastructure.Persistence.Repositories.Users;

namespace MyEShop.Infrastructure;

public static class InfrastructureConfigs
{
    public static IServiceCollection RegisterInfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context

        services.AddDbContext<MyEShopDbContext>(options =>
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