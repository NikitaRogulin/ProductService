using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record UpdateSalesPointRequest(long Id, string Name, ICollection<SalesPointProduct> ProvidedProducts, ICollection<Sale> Sales);