namespace ProductService.Products.Domain.Models;

public class SalesPointProduct
{
    public long Id { get; set; }
    public long SalesPointId { get;  set; }
    public SalesPoint SalesPoint { get;  set; }
    public long ProductId { get;  set; }
    public Product Product { get;  set; }
    public int Quantity { get; set; }
}