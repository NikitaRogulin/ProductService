namespace ProductService.Products.Domain.Models;

public class Sale
{
    public long Id { get; set; }
    public DateTime DateSale { get; set; }
    public long SalesPointId { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public SalesPoint SalesPoint { get; set; }
    public int ProductQuantity { get; set; }
    public decimal ProductAmount { get; set; }
    
}