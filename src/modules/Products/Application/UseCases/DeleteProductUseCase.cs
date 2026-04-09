using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;

namespace MyInventory2026.src.modules.Products.Application.UseCases;

public sealed class DeleteProductUseCase
{
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> ExecuteAsync(int id, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var existingProduct = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (existingProduct is null)
        {
            return false;
        }

        return await _productRepository.DeleteByIdAsync(productId, cancellationToken);
    }
}