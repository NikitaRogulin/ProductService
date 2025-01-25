using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SaleProductAggregateConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.HasKey(x => new { x.SaleId, x.ProductId });
            
        builder.HasOne(x => x.Sale)
            .WithMany(x => x.SalesData)
            .HasForeignKey(x => x.SaleId);
        
        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }
}