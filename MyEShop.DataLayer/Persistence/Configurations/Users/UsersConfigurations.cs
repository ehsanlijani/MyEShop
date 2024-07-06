using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Domain.Entities.Users;

namespace MyEShop.Infrastructure.Persistence.Configurations.Users;

public class UsersConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(p => p.Id)
            .IsClustered();

        builder
            .Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder
            .Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}

