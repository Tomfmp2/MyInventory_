using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.modules.Products.Domain.aggregate;
using MyInventory2026.src.modules.Products.Domain.Repositories;
using MyInventory2026.src.modules.Products.Domain.valueObject;
using MyInventory2026.src.modules.Products.Infrastructure.Entity;
using MyInventory2026.src.shared.context;

namespace MyInventory2026.src.modules.Products.Infrastructure.repository;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        var entity = new ProductEntity
        {
            id = product.Id.Value,
            NameProduct = product.Name.Value
        };

        await _dbContext.Products.AddAsync(entity, cancellationToken);
    }

    public async Task<Product?> FindByIdAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id.Value, cancellationToken);

        return entity is null ? null : Product.Create(entity.id, entity.NameProduct);
    }

    public async Task<IReadOnlyCollection<Product>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Products
            .AsNoTracking()
            .OrderBy(x => x.NameProduct)
            .ToListAsync(cancellationToken);

        return entities.Select(x => Product.Create(x.id, x.NameProduct)).ToList();
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.id == product.Id.Value, cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException($"Product with id '{product.Id.Value}' was not found.");
        }

        entity.NameProduct = product.Name.Value;
    }

    public async Task<bool> DeleteByIdAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.id == id.Value, cancellationToken);

        if (entity is null)
        {
            return false;
        }

        _dbContext.Products.Remove(entity);
        return true;
    }
}