using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Host.Controllers;

[ApiController]
[Route(WebRoutes.Product.Path)]
public class ProductController : ControllerBase
{
    private IProductsService _productService;
    public ProductController(IProductsService productService)
    {
        _productService = productService;
    }
    [HttpPost(WebRoutes.Product.Create)]
    public Task<Guid> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        return _productService.Create(request.Name, request.Price, cancellationToken);
    }

    [HttpGet(WebRoutes.Product.GetById)]
    public Task<Product> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _productService.GetById(id, cancellationToken);
    }

    [HttpPut(WebRoutes.Product.Update)]
    public Task Update([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        return _productService.Update(request.Id, request.Name, request.Price);
    }

    [HttpDelete(WebRoutes.Product.Delete)]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return _productService.Delete(id, cancellationToken);
    }
    
}