using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyInventory2026.src.modules.Products.Infrastructure.Entity;

namespace MyInventory2026.src.modules.provider.Infrastructure.entity;

public sealed class ProviderProductEntityConfiguration : IEntityTypeConfiguration<ProviderProductEntity>
{
    public void Configure(EntityTypeBuilder<ProviderProductEntity> builder)
    {
        builder.ToTable("provider_products");

        builder.HasKey(x => new { x.ProviderId, x.ProductId });

        builder.Property(x => x.ProviderId)
            .HasColumnName("provider_id")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.HasOne(x => x.Provider)
            .WithMany(x => x.ProviderProducts)
            .HasForeignKey(x => x.ProviderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProviderProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
