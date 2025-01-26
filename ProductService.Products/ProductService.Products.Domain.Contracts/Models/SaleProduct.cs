namespace ProductService.Products.Domain.Contracts.Models;

public class SaleProduct
{
    public long SaleId { get; private set; }
    public Sale Sale { get; private set; }

    public long ProductId { get; private set; }
    public Product Product { get; private set; }
    
    public int ProductQuantity { get; private set; }
    public decimal ProductAmount { get; private set; }
    

    public SaleProduct(long saleId, Sale sale, long productId, Product product, int productQuantity)
    {
        SaleId = saleId;
        Sale = sale;
        ProductId = productId;
        Product = product;
        ProductQuantity = productQuantity;
        ProductAmount = ProductQuantity * Product.Price;
    }
}