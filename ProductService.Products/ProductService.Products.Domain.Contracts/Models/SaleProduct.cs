namespace ProductService.Products.Domain.Contracts.Models;

public class SaleProduct
{
    public Guid SaleId { get; private set; }
    public Sale Sale { get; private set; }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    
    public int ProductQuantity { get; private set; }
    public decimal ProductAmount { get; private set; }
    

    public SaleProduct(Guid saleId, Sale sale, Guid productId, Product product, int productQuantity)
    {
        SaleId = saleId;
        Sale = sale;
        ProductId = productId;
        Product = product;
        ProductQuantity = productQuantity;
        ProductAmount = ProductQuantity * Product.Price;
    }
}