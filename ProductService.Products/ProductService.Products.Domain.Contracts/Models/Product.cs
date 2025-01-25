namespace ProductService.Products.Domain.Contracts.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get;  set; }
    public decimal Price { get; set; }

    public ICollection<SalesPointProduct> ProvidedProducts { get; private set;}

    public Product(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}