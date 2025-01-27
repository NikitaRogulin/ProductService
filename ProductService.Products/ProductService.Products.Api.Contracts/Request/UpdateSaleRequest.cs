using ProductService.Products.Domain.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record UpdateSaleRequest(long Id, DateTime DateTime, long SalesPointId, long ProductId, Product Product,
    SalesPoint SalesPoint, int ProductQuantity);