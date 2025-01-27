using ProductService.Products.Domain.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record UpdateSalesPointRequest(long Id, string Name, List<SalesPointProduct> ProvidedProducts, List<Sale> Sales);