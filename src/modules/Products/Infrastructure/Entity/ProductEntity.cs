using System;
using System.Security.Cryptography.X509Certificates;

namespace MyInventory2026.src.modules.Products.Infrastructure.Entity;

public class ProductEntity
{
    public int id { get; set; }
    public object? Id { get; internal set; }
    public string? CodeInv { get; set; }
    public int stok { get; set; }
    public int stokMin { get; set; }
    public int stokMax { get; set; }

}
