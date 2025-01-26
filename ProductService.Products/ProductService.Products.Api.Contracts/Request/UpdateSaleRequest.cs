using ProductService.Products.Domain.Contracts.Models;
namespace ProductService.Products.Api.Contracts.Request;

public record UpdateSaleRequest(long Id, DateTime Date, long SalesPointId, ICollection<SaleProduct> SalesData);