namespace ProductService.Products.Domain.Contracts.Models;

public class SalesPoint
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<ProvidedProduct> ProvidedProducts { get; private set; }

    public SalesPoint(string name, IEnumerable<ProvidedProduct> providedProducts)
    {
        Id = Guid.NewGuid();
        Name = name;
        ProvidedProducts = providedProducts;
    }
}