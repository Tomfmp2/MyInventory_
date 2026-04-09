using MyInventory2026.src.modules.Products.Domain.valueObject;

namespace MyInventory2026.src.modules.Products.Domain.aggregate;

public class Product
{
    public ProductId Id { get; init; }
    public ProductName Name { get; init; }

    private Product(ProductId id, ProductName name)
    {
        Id = id;
        Name = name;
    }

    public static Product Create(int id, string name)
    {
        return new Product(
            ProductId.Create(id),
            ProductName.Create(name)
        );
    }
}