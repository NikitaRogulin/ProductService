using Microsoft.AspNetCore.Mvc;
using ProductService.Products.Api.Contracts;
using ProductService.Products.Api.Contracts.Request;
using ProductService.Products.AppServices.SalesPointService;
using ProductService.Products.Domain.Models;

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
    /// <summary>
    /// Создает новую точку продаж
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для создания точки продаж</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Идентификатор созданной точки продаж</returns>
    [HttpPost(WebRoutes.SalesPoint.Create)]
    public Task<long> Create([FromBody] CreateSalesPointRequest request, CancellationToken cancellationToken)
    {
        return _salePointService.Create(request.Id, request.Name, request.ProvidedProducts, request.Sales,
            cancellationToken);
    }
    /// <summary>
    /// Получает точку продаж по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор точки продаж, которую необходимо получить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Точка продаж с указанным идентификатором</returns>
    [HttpGet(WebRoutes.SalesPoint.GetById)]
    public Task<SalesPoint> GetSalesPoint([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _salePointService.GetById(id, cancellationToken);
    }
    /// <summary>
    /// Обновляет информацию о точке продаж
    /// </summary>
    /// <param name="request">Объект запроса, содержащий данные для обновления точки продаж</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию обновления точки продаж</returns>
    [HttpPut(WebRoutes.SalesPoint.Update)]
    public Task Update([FromBody] UpdateSalesPointRequest request, CancellationToken cancellationToken)
    {
        return _salePointService.Update(request.Id, request.Name, request.ProvidedProducts, request.Sales,
            cancellationToken);
    }
    /// <summary>
    /// Удаляет точку продаж по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор точки продаж, которую необходимо удалить</param>
    /// <param name="cancellationToken">Токен отмены для управления асинхронными операциями</param>
    /// <returns>Задача, представляющая операцию удаления  точки продаж</returns>
    [HttpDelete(WebRoutes.SalesPoint.Delete)]
    public Task Delete([FromRoute] long id, CancellationToken cancellationToken)
    {
        return _salePointService.Delete(id, cancellationToken);
    }
}