namespace ProductService.Products.Api.Contracts.Request;

public record UpdateProductRequest(Guid Id ,string Name, decimal Price);