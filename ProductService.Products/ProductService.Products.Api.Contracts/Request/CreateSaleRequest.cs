using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record CreateSaleRequest(long Id, DateTime DateTime, long SalePointId, ICollection<SaleProduct> SaleProducts);