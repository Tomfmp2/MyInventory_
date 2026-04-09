using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;

namespace MyInventory2026.src.modules.Products.Application.UseCases;

public sealed class UpdateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public UpdateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> ExecuteAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var existingProduct = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (existingProduct is null)
        {
            throw new KeyNotFoundException($"Product with id '{productId}' was not found.");
        }

        var updatedProduct = Product.Create(id, name);
        await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
        return updatedProduct;
    }
}