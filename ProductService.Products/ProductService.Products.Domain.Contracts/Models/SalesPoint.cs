namespace ProductService.Products.Domain.Contracts.Models;

public class SalesPoint
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<SalesPointProduct>? ProvidedProducts { get; private set; }
    public ICollection<Sale> Sales { get; private set;}

    public SalesPoint(string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales)
    {
        Id = Guid.NewGuid();
        Name = name;
        ProvidedProducts = providedProducts;
        Sales = sales;
    }
}