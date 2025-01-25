namespace ProductService.Products.Domain.Contracts.Models;

public class Sale
{
    public Guid Id { get; private set; }
    public DateTime Date { get;  set; }
    public Guid SalesPointId { get;  set; }
    public SalesPoint SalesPoint { get; set; }
    public ICollection<SaleProduct> SalesData { get; set; }

    public Sale(Guid id, DateTime date, Guid salesPointId, ICollection<SaleProduct> salesData)
    {
        Id = id;
        Date = date;
        SalesPointId = salesPointId;
        SalesData = salesData;
    }
    
}