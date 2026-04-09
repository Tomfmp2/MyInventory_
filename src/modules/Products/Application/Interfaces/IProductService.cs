using MyInventory2026.src.modules.Products.Domain.aggregate;

namespace MyInventory2026.src.modules.Products.Application.Interfaces;

public interface IProductService
{
    Task<Product> CreateAsync(int id, string name, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(int id, string name, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}