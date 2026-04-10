using MyInventory2026.src.modules.Products.Infrastructure.Entity;

namespace MyInventory2026.src.modules.provider.Infrastructure.entity;

public sealed class ProviderProductEntity
{
    public string ProviderId { get; set; } = string.Empty;
    public int ProductId { get; set; }

    public ProviderEntity? Provider { get; set; }
    public ProductEntity? Product { get; set; }
}
