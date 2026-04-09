using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;

namespace MyInventory2026.src.modules.Products.Application.UseCases;

public sealed class GetAllProductsUseCase
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IReadOnlyCollection<Product>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        return _productRepository.FindAllAsync(cancellationToken);
    }
}