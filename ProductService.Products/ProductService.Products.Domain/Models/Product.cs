namespace ProductService.Products.Domain.Models;

public class Product
{
    public long Id { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(long id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}