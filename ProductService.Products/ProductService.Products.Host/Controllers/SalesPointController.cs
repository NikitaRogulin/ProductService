using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Host.Controllers;

[ApiController]
[Route(WebRoutes.SalesPoint.Path)]
public class SalesPointController : ControllerBase
{
    private ISalesPointService _salePointService;
    
    public SalesPointController(ISalesPointService salePointService)
    {
        _salePointService = salePointService;
    }
    [HttpPost(WebRoutes.SalesPoint.Create)]
    public Task<Guid> Create([FromBody] CreateSalesPointRequest request, CancellationToken cancellationToken)
    {
        return _salePointService.Create(request.Name, request.ProvidedProducts, request.Sales ,cancellationToken);
    }

    [HttpGet(WebRoutes.SalesPoint.GetById)]
    public Task<SalesPoint> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _salePointService.GetById(id, cancellationToken);
    }

    [HttpPut(WebRoutes.SalesPoint.Update)]
    public Task Update([FromBody] UpdateSalesPointRequest request, CancellationToken cancellationToken)
    {
        return _salePointService.Update(request.Id, request.Name, request.ProvidedProducts, request.Sales, cancellationToken);
    }

    [HttpDelete(WebRoutes.SalesPoint.Delete)]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _salePointService.Delete(id, cancellationToken);
    }

    [HttpPut(WebRoutes.SalesPoint.Sell)]
    public Task Sell([FromBody] SellRequest request, CancellationToken cancellationToken)
    {
        return _salePointService.Sell(request.Id, request.SalesPointProducts.ToList(), request.Money);
    }
}