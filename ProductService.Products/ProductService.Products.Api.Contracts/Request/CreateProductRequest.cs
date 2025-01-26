namespace ProductService.Products.Api.Contracts.Request;

public record CreateProductRequest(long Id, string Name, decimal Price);