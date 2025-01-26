namespace ProductService.Products.Domain.Contracts.Models;

public class Sale
{
    public long Id { get; private set; }
    public DateTime Date { get;  set; }
    public long SalesPointId { get;  set; }
    public SalesPoint SalesPoint { get; set; }
    public ICollection<SaleProduct> SalesData { get; set; }

    public Sale(long id, DateTime date, long salesPointId, ICollection<SaleProduct> salesData)
    {
        Id = id;
        Date = date;
        SalesPointId = salesPointId;
        SalesData = salesData;
    }
    
}