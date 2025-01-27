using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.Models;
using ProductService.Products.Persistence.Configurations;

namespace ProductService.Products.Persistence;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SalesPointProduct> SaleDatas { get; set; }
    public DbSet<SalesPoint> SalePoints { get; set; }

    public ProductsContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SaleConfiguration());
        modelBuilder.ApplyConfiguration(new SalePointProductConfiguration());
        modelBuilder.ApplyConfiguration(new SalesPointConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}