using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Domain.Entities.Products;

namespace MyEShop.Infrastructure.Persistence.Configurations.Products;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {

        builder
            .HasKey(p => p.Id)
            .IsClustered();

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder
          .Property(p => p.TitleInUrl)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);
    }
}
