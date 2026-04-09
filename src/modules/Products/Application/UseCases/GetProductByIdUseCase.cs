using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;

namespace MyInventory2026.src.modules.Products.Application.UseCases;

public sealed class GetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product?> ExecuteAsync(int id, CancellationToken cancellationToken = default)
    {
        return _productRepository.FindByIdAsync(ProductId.Create(id), cancellationToken);
    }
}