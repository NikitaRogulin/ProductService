using ProductService.Products.Domain.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using ProductService.Products.Persistence.Configurations;

namespace ProductService.Products.Persistence;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<SaleProduct> ProvidedProducts { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SalesPointProduct> SaleDatas { get; set; }
    public DbSet<SalesPoint> SalePoints { get; set; }

    public ProductsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductAggregateConfiguration());
        modelBuilder.ApplyConfiguration(new SaleProductAggregateConfiguration());
        modelBuilder.ApplyConfiguration(new SaleAggregateConfiguration());
        modelBuilder.ApplyConfiguration(new SalePointProductAggregateConfiguration());
        modelBuilder.ApplyConfiguration(new SalesPointAggregateConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}