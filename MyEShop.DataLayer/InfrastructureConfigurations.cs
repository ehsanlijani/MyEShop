using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyEShop.Domain.IRepositories.Common;
using MyEShop.Infrastructure.Persistence.Context;
using MyEShop.Infrastructure.Persistence.Repositories.Common;

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

        var assembly = typeof(InfrastructureConfigs).Assembly;

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var repositoryTypes = assembly.GetTypes()
            .Where(t => !t.IsInterface && !t.IsAbstract)
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGenericRepository<>)))
            .Select(t => new
            {
                ImplementationType = t,
                InterfaceType = t.GetInterfaces().FirstOrDefault(i => !i.IsGenericType)
            })
            .Where(t => t.InterfaceType is not null);

        foreach (var repository in repositoryTypes)
        {
            services.AddScoped(repository.InterfaceType, repository.ImplementationType);
        }

        #endregion

        return services;
    }
}