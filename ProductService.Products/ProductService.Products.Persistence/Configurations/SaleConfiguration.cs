using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Product>(x => x.Product)
            .WithMany().HasForeignKey(x => x.ProductId);
        builder.HasOne<SalesPoint>()
            .WithMany(x => x.TotalSales).HasForeignKey(x => x.SalesPointId);

        builder.ToTable("sales");
        builder.Property(x => x.Id);
        builder.Property(x => x.DateSale);
    }
}