using System;

namespace MyInventory2026.src.modules.Products.Domain.valueObject;

public class ProductId
{
    public int Value { get; }

    public ProductId(int value)
    {
        Value = value;
    }

    public static ProductId Create(int value)
    {
        return new ProductId(value);
    }

    public override bool Equals(object? obj) => obj is ProductId other && Value.Equals(other.Value);
    public override int GetHashCode() => Value.GetHashCode();
}