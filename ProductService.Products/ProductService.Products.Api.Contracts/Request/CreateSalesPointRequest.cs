using ProductService.Products.Domain.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record CreateSalesPointRequest(long Id, string Name, List<SalesPointProduct> ProvidedProducts, List<Sale> Sales);