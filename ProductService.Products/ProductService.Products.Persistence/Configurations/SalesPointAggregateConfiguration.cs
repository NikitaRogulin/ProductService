using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SalesPointAggregateConfiguration : IEntityTypeConfiguration<SalesPoint>
{
    public void Configure(EntityTypeBuilder<SalesPoint> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable("sales point");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.ProvidedProducts).HasColumnName("provided products");
        builder.Property(x => x.Sales).HasColumnName("sales");
    }
}