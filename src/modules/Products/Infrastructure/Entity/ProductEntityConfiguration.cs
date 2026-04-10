using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyInventory2026.src.modules.Products.Infrastructure.Entity;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.CodeInv)
            .HasColumnName("code_inv")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.NameProduct)
            .HasColumnName("name_product")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.stok)
            .HasColumnName("stok")
            .IsRequired();

        builder.Property(x => x.stokMin)
            .HasColumnName("stok_min")
            .IsRequired();

        builder.Property(x => x.stokMax)
            .HasColumnName("stok_max")
            .IsRequired();
    }
}
