using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyEShop.Application.Profiles.ProductCategory;
using MyEShop.Application.Services.Implementations;
using MyEShop.Application.Services.Interfaces;
using MyEShop.Domain.Entities.Users;
using System.Reflection;
using System.Text;

namespace MyEShop.Application;

public static class ApplicationConfigs
{
    public static IServiceCollection RegisterApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterFluentValidation(services);

        RegisterMediatR(services);

        RegisterAutoMapper(services);

        AddIdentityService(services, configuration);

        RegisterServices(services);

        return services;
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ProductCategoryProfile).Assembly,
            typeof(User).Assembly);
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }

    private static void RegisterFluentValidation(this IServiceCollection services)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddFluentValidation(configuration =>
        {
            var validatorTypes = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                            t.GetInterfaces().Any(i => i.IsGenericType &&
                                                       i.GetGenericTypeDefinition() == typeof(IValidator<>)));

            foreach (var validatorType in validatorTypes)
            {
                configuration.RegisterValidatorsFromAssemblyContaining(validatorType);
            }
        });
    }

    private static void RegisterMediatR(this IServiceCollection services)
    {
        Assembly assembly = typeof(ApplicationConfigs).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));
    }

    private static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                };
            });
    }
}

