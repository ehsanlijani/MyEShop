using Microsoft.EntityFrameworkCore;
using MyEShop.Domain.Contracts.Common;
using System.Reflection;
using IEntity = MyEShop.Domain.Contracts.Common.IEntity;

namespace MyEShop.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder RegisterAllSeeders(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        var seederTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(IsValidSeederType);

        foreach (var seederType in seederTypes)
        {
            var seeder = Activator.CreateInstance(seederType);
            modelBuilder
                .Entity(GetEntityType(seederType))
                .HasData(GetSeedData(seederType, seeder));
        }
        return modelBuilder;
    }

    private static bool IsValidSeederType(Type type)
        => type is { IsClass: true, IsAbstract: false, IsPublic: true } &&
           type.GetInterfaces()
               .Any(i =>
                   i.IsGenericType &&
                   i.GetGenericTypeDefinition() == typeof(IBaseSeeder<>));

    private static IEnumerable<IEntity> GetSeedData(Type seederType, object seederInstance)
    {
        var seedDataMethod = seederType.GetMethod(nameof(IBaseSeeder<IEntity>.GetSeedData));
        return seedDataMethod?.Invoke(seederInstance, null) as IEnumerable<IEntity> ?? Enumerable.Empty<IEntity>();
    }

    private static Type GetEntityType(Type seederType)
        => seederType.GetInterfaces()
            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseSeeder<>))
            .GenericTypeArguments[0];
}

