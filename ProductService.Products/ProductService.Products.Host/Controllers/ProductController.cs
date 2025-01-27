using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices.ProductService;
using ProductService.Products.Domain.Models;

namespace ProductService.Products.Host.Controllers;

[ApiController]
[Route(WebRoutes.Product.Path)]
public class ProductController : ControllerBase
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Создает новый продукт
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для создания нового продукта</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Идентификатор созданного продукта</returns>
    [HttpPost(WebRoutes.Product.Create)]
    public Task<long> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        return _productService.Create(request.Id, request.Name, request.Price, cancellationToken);
    }

    /// <summary>
    /// Получает продукт по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор продукта, который необходимо получить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Продукт с указанным идентификатором</returns>
    [HttpGet(WebRoutes.Product.GetById)]
    public Task<Product> GetProduct([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _productService.GetById(id, cancellationToken);
    }
    /// <summary>
    /// Обновляет информацию о продукте
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для обновления продукта</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию обновления продукта</returns>
    [HttpPut(WebRoutes.Product.Update)]
    public Task Update([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        return _productService.Update(request.Id, request.Name, request.Price, cancellationToken);
    }
    /// <summary>
    /// Удаляет продукт по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор продукта, который необходимо удалить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию удаления продукта</returns>
    [HttpDelete(WebRoutes.Product.Delete)]
    public Task Delete([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _productService.Delete(id, cancellationToken);
    }
}