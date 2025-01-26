using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record SellRequest(long Id, ICollection<SalesPointProduct> SalesPointProducts, decimal Money);