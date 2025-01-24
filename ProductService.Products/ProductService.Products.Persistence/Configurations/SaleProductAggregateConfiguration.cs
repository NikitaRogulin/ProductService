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
        
        builder.ToTable("sale product");
        builder.Property(x => x.SaleId).HasColumnName("sale id");
        builder.Property(x => x.ProductId).HasColumnName("product id");
        builder.Property(x => x.ProductQuantity).HasColumnName("product quantity");
        builder.Property(x => x.ProductAmount).HasColumnName("product amount");

    }
}