using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices.SaleService;
using ProductService.Products.Domain.Models;

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
    /// <summary>
    /// Создает новую продажу
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для создания продажи</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Идентификатор созданной продажи</returns>
    [HttpPost(WebRoutes.Sale.Create)]
    public Task<long> Create([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        return _saleService.Create(request.Id, request.DateTime, request.SalesPointId, request.ProductId,
            request.Product, request.SalesPoint, request.ProductQuantity, cancellationToken);
    }
    /// <summary>
    /// Получает продажу по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор продажи, которую необходимо получить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Продажа с указанным идентификатором</returns>
    [HttpGet(WebRoutes.Sale.GetById)]
    public Task<Sale> GetSale([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _saleService.GetById(id, cancellationToken);
    }
    /// <summary>
    /// Обновляет информацию о продаже
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для обновления продажи</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию обновления продажи</returns>
    [HttpPut(WebRoutes.Sale.Update)]
    public Task Update([FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        return _saleService.Update(request.Id, request.DateTime, request.SalesPointId, request.ProductId,
            request.Product, request.SalesPoint, request.ProductQuantity, cancellationToken);
    }
    /// <summary>
    /// Удаляет продажу по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор продажи, которую необходимо удалить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию удаления продажи</returns>
    [HttpDelete(WebRoutes.Sale.Delete)]
    public Task Delete([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _saleService.Delete(id, cancellationToken);
    }
}