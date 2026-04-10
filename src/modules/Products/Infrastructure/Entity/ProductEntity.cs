using System.Collections.Generic;
using MyInventory2026.src.modules.provider.Infrastructure.entity;

namespace MyInventory2026.src.modules.Products.Infrastructure.Entity;

public class ProductEntity
{
    public int id { get; set; }
    public string? CodeInv { get; set; }
    public string NameProduct { get; set; } = string.Empty;
    public int stok { get; set; }
    public int stokMin { get; set; }
    public int stokMax { get; set; }

    public ICollection<ProviderProductEntity> ProviderProducts { get; } = new List<ProviderProductEntity>();
}
