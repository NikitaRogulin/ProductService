namespace ProductService.Products.Api.Contracts.Request;

public record UpdateProductRequest(long Id ,string Name, decimal Price);