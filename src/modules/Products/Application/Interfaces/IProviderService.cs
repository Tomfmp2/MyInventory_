using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Infrastructure.repository;

namespace MyInventory2026.src.modules.Products.Application.Interfaces;

public interface IProductsService
{
    Task<Product> CreateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(string id, string name, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
}
