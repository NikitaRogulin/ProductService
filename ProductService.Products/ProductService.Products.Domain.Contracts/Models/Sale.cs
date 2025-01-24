namespace ProductService.Products.Domain.Contracts.Models;

public class Sale
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public Guid SalesPointId { get; private set; }
    public SalesPoint SalesPoint { get; set; }
    public ICollection<SaleProduct> SalesData { get; private set; }

    public Sale(DateTime date, Guid salesPointId, ICollection<SaleProduct> salesData)
    {
        Id = Guid.NewGuid();
        Date = date;
        SalesPointId = salesPointId;
        SalesData = salesData;
    }
    
}