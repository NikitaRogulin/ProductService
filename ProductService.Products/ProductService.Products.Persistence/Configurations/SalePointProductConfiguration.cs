using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Models;


namespace ProductService.Products.Persistence.Configurations;

public class SalePointProductConfiguration : IEntityTypeConfiguration<SalesPointProduct>
{
    public void Configure(EntityTypeBuilder<SalesPointProduct> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany().HasForeignKey(x => x.ProductId);
    }
}