using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;

namespace MyInventory2026.src.modules.Products.Application.UseCases;

public sealed class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> ExecuteAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var existingProduct = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (existingProduct is not null)
        {
            throw new InvalidOperationException($"Product with id '{productId}' already exists.");
        }

        var product = Product.Create(id, name);
        await _productRepository.AddAsync(product, cancellationToken);
        return product;
    }
}