using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Api.Contracts.Request;

public record CreateSaleRequest(DateTime DateTime, Guid SalePointId, ICollection<SaleProduct> SaleProducts);