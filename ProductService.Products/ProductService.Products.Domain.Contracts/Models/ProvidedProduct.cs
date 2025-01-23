namespace ProductService.Products.Domain.Contracts.Models;

public class ProvidedProduct
{
    public Product Product { get; private set; }
    public Guid Id { get; private set; }
    public int ProductOuantity { get; private set; }

    public decimal ProductAmount { get; private set; }

    public ProvidedProduct(Guid id, Product product, int quantity)
    {
        Id = id;
        Product = product;
        ProductOuantity = quantity;
        ProductAmount =  ProductOuantity * Product.Price;
    }
}