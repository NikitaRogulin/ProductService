using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Host.Controllers;

[ApiController]
[Route(WebRoutes.Sale.Path)]
public class SaleController : ControllerBase
{
    private ISaleService _saleService;
    
    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    [HttpPost(WebRoutes.Sale.Create)]
    public Task<Guid> Create([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        return _saleService.Create(request.DateTime, request.SalePointId, request.SaleProducts ,cancellationToken);
    }

    [HttpGet(WebRoutes.Sale.GetById)]
    public Task<Sale> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _saleService.GetById(id, cancellationToken);
    }

    [HttpPut(WebRoutes.Sale.Update)]
    public Task Update([FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        return _saleService.Update(request.Id, request.Date, request.SalesPointId, request.SalesData, cancellationToken);
    }

    [HttpDelete(WebRoutes.Sale.Delete)]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _saleService.Delete(id, cancellationToken);
    }
}