namespace ProductService.Products.Domain.Contracts.Models;

public class SalesPointProduct
{
    public Guid SalesPointId { get; private set; }
    public SalesPoint SalesPoint { get; private set; }
    public Guid ProductId { get;  private set; }
    public Product Product { get; private set; }
    
    public int Quantity { get; private set; }
    
    public SalesPointProduct(Guid salesPointId, SalesPoint salesPoint,Guid productId, Product product ,int quantity)
    {
        SalesPointId = salesPointId;
        SalesPoint = salesPoint;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
    }
}