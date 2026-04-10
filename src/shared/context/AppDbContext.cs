using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.modules.provider.Infrastructure.entity;
using MyInventory2026.src.modules.Products.Infrastructure.Entity;

namespace MyInventory2026.src.shared.context;

public class AppDbContext : DbContext
{
    public DbSet<ProviderEntity> Providers => Set<ProviderEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<ProviderProductEntity> ProviderProducts => Set<ProviderProductEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
