using ProductService.Products.Domain.Contracts.Models;
namespace ProductService.Products.Api.Contracts.Request;

public record UpdateSaleRequest(Guid Id, DateTime Date, Guid SalesPointId, ICollection<SaleProduct> SalesData);