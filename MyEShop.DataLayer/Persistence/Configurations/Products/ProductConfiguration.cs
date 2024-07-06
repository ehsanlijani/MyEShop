using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Infrastructure.Persistence.Configurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
           .HasKey(p => p.Id)
           .IsClustered();

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder
           .Property(p => p.Price)
           .HasDefaultValue(0)
           .IsRequired();

        builder
            .Property(p => p.Quantity)
            .HasDefaultValue(0)
            .IsRequired();

        builder
         .Property(p => p.ShortDescription)
         .IsRequired()
         .HasMaxLength(300)
         .IsUnicode(false);

        builder
         .Property(p => p.Description)
         .IsRequired()
         .HasMaxLength(3000)
         .IsUnicode(false);
    }
}
