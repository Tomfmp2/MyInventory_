using MyInventory2026.src.modules.Products.Application.Interfaces;
using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;
using MyInventory2026.src.shared.contracts;

namespace MyInventory2026.src.modules.Products.Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> CreateAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var existingProduct = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (existingProduct is not null)
        {
            throw new InvalidOperationException($"Product with id '{productId}' already exists.");
        }

        var product = Product.Create(id, name);
        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return product;
    }

    public Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _productRepository.FindByIdAsync(ProductId.Create(id), cancellationToken);
    }

    public Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _productRepository.FindAllAsync(cancellationToken);
    }

    public async Task<Product> UpdateAsync(int id, string name, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var existingProduct = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (existingProduct is null)
        {
            throw new KeyNotFoundException($"Product with id '{productId}' was not found.");
        }

        var updatedProduct = Product.Create(id, name);
        await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return updatedProduct;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var productId = ProductId.Create(id);
        var wasDeleted = await _productRepository.DeleteByIdAsync(productId, cancellationToken);

        if (!wasDeleted)
        {
            return false;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}