using System;

namespace MyInventory2026.src.modules.Products.Domain.valueObject;

public class ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty", nameof(value));
        Value = value;
    }

    public static ProductName Create(string value)
    {
        return new ProductName(value);
    }

    public override bool Equals(object? obj) => obj is ProductName other && Value.Equals(other.Value);
    public override int GetHashCode() => Value.GetHashCode();
}