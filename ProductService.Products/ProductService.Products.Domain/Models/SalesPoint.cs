namespace ProductService.Products.Domain.Models;

public class SalesPoint
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<SalesPointProduct> ProvidedProducts { get; set; } = new List<SalesPointProduct>();
    public List<Sale> TotalSales { get; set; } = new List<Sale>();
}