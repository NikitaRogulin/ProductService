using ProductService.Products.Domain;
using ProductService.Products.Domain.Models;

namespace ProductService.Products.AppServices.SalesPointService;

public class SalesPointService : ISalesPointService
{
    private readonly IUnitOfWork _unitOfWork;

    public SalesPointService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<long> Create(long id, string name, List<SalesPointProduct> providedProducts, List<Sale> sales,
        CancellationToken cancellationToken = default)
    {
        var salesPoint = new SalesPoint()
        {
            Id = id,
            Name = name,
        };
        _unitOfWork.SalesPointRepository.Create(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
        return salesPoint.Id;
    }

    public async Task<SalesPoint> GetById(long id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new InvalidOperationException($"Не удалось получить точку продажи по такому id - {id}");
        }
        return salesPoint;
    }
    public async Task Update(long id, string name, List<SalesPointProduct> providedProducts, List<Sale> sales,
        CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new InvalidOperationException($"Не удалось обновить точку продажи с таким id - {id}");
        }

        salesPoint.Name = name;
        salesPoint.ProvidedProducts = providedProducts;
        
        _unitOfWork.SalesPointRepository.Update(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Delete(long id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new InvalidOperationException($"Не удалось удалить продажу с таким id -{id}");
        }
        _unitOfWork.SalesPointRepository.Delete(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}