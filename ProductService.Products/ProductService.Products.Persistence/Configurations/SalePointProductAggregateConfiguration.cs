using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SalePointProductAggregateConfiguration : IEntityTypeConfiguration<SalesPointProduct>
{
    public void Configure(EntityTypeBuilder<SalesPointProduct> builder)
    {
        
        builder.HasKey(x => new { x.SalesPointId, x.ProductId });
        builder.HasOne(x => x.SalesPoint)
            .WithMany(x => x.ProvidedProducts).HasForeignKey(x => x.SalesPointId);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProvidedProducts)
            .HasForeignKey(x => x.ProductId);
            
        builder.ToTable("sale point product");
        builder.Property(x => x.ProductId).HasColumnName("product id");
        builder.Property(x => x.SalesPointId).HasColumnName("sales point id");
        builder.Property(x => x.Quantity).HasColumnName("quantity");
    }
}