using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record SellRequest(Guid Id, ICollection<SalesPointProduct> SalesPointProducts, decimal Money);