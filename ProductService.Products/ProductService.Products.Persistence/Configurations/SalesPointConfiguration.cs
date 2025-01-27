using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SalesPointConfiguration : IEntityTypeConfiguration<SalesPoint>
{
    public void Configure(EntityTypeBuilder<SalesPoint> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.ProvidedProducts)
            .WithOne(x => x.SalesPoint)
            .HasForeignKey(x => x.SalesPointId);
        
        builder.HasMany(x => x.TotalSales)
            .WithOne(x => x.SalesPoint)
            .HasForeignKey(x => x.SalesPointId);
        
        builder.ToTable("sales_point");
        builder.Property(x => x.Id);
        builder.Property(x => x.Name);
    }
}