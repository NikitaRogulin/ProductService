using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Persistence.Configurations;

public class SaleAggregateConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.SalesPoint)
            .WithMany(x => x.Sales)
            .HasForeignKey(x => x.SalesPointId);
        
        builder.ToTable("sales");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Date).HasColumnName("date");
        builder.Property(x => x.SalesPointId).HasColumnName("sale point id");
        builder.Property(x => x.SalesData).HasColumnName("sales data");
    }
}