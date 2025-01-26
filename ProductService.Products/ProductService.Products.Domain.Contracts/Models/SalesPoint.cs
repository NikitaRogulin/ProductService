namespace ProductService.Products.Domain.Contracts.Models;

public class SalesPoint
{
    public long Id { get; private set; }
    public string Name { get; set; }
    public ICollection<SalesPointProduct>? ProvidedProducts { get; set; }
    public ICollection<Sale>? Sales { get;  private set;}

    public SalesPoint(long id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales)
    {
        Id = id;
        Name = name;
        ProvidedProducts = providedProducts;
        Sales = sales;
    }
}