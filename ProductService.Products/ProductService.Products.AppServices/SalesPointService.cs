using ProductService.Products.Domain;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public class SalesPointService : ISalesPointService
{
    private readonly IUnitOfWork _unitOfWork;

    public SalesPointService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Create(string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales,
        CancellationToken cancellationToken = default)
    {
        var salesPoint = new SalesPoint(Guid.NewGuid(), name, providedProducts, sales);
        _unitOfWork.SalesPointRepository.Create(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
        return salesPoint.Id;
    }

    public async Task<SalesPoint> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось получить точку продажи по такому id - {id}");
        }
        return salesPoint;
    }
    public async Task Update(Guid id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales,
        CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось обновить точку продажи с таким id - {id}");
        }

        salesPoint.Name = name;
        salesPoint.ProvidedProducts = providedProducts;
        
        _unitOfWork.SalesPointRepository.Update(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось удалить продажу с таким id -{id}");
        }
        _unitOfWork.SalesPointRepository.Delete(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Sell(Guid salesPointId, List<SalesPointProduct> salesPointProducts,  decimal money, CancellationToken cancellationToken = default )
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(salesPointId, cancellationToken);
        
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось получить точку продажи с таким id -{salesPointId}");
        }

        var providedProducts = salesPoint.ProvidedProducts
            .Where(pp => salesPointProducts.Contains());
        
        
        /*if (salesPointProducts.All(salesPoint.ProvidedProducts.Contains))
        {
            for (int i = 0; i < salesPointProducts.Count; i++)
            {
                var salesProduct = salesPointProducts[i];
                for (int j = 0; j < salesPoint.ProvidedProducts.Count; j++)
                {
                    var providedProducts = salesPoint.ProvidedProducts.ToList();
                    if (salesProduct.ProductId == providedProducts[j].ProductId && providedProducts[j].Quantity != 0)
                    {

                    }
                }
            }
        }*/
    }
}