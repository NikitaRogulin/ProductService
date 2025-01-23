namespace ProductService.Products.Domain.Contracts.Models;

public class Sale
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public Guid SalesPointId { get; private set; }
    public IReadOnlyCollection<ProvidedProduct> SalesData { get; private set; }

    public Sale(DateTime date, Guid salesPointId, IReadOnlyCollection<ProvidedProduct> salesData)
    {
        Id = Guid.NewGuid();
        Date = date;
        SalesPointId = salesPointId;
        SalesData = salesData;
    }
}

public class PurchasedProduct
{
    public Guid id { get; private set; }
    public Guid ProvidedProductId { get; private set; }
    
}