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
    
    public async Task<long> Create(long id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales,
        CancellationToken cancellationToken = default)
    {
        var salesPoint = new SalesPoint(id, name, providedProducts, sales);
        _unitOfWork.SalesPointRepository.Create(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
        return salesPoint.Id;
    }

    public async Task<SalesPoint> GetById(long id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось получить точку продажи по такому id - {id}");
        }
        return salesPoint;
    }
    public async Task Update(long id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales,
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

    public async Task Delete(long id, CancellationToken cancellationToken = default)
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(id, cancellationToken);
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось удалить продажу с таким id -{id}");
        }
        _unitOfWork.SalesPointRepository.Delete(salesPoint);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Sell(long salesPointId, List<SalesPointProduct> salesPointProducts,  decimal money, CancellationToken cancellationToken = default )
    {
        var salesPoint = await _unitOfWork.SalesPointRepository.GetById(salesPointId, cancellationToken);
        
        if (salesPoint == null)
        {
            throw new Exception($"Не удалось получить точку продажи с таким id -{salesPointId}");
        }

        var isProductValid = salesPoint.ProvidedProducts
            .All(x => salesPointProducts
                .Select(x => x.ProductId)
                .Contains(x.ProductId));

        if (!isProductValid)
        {
            throw new Exception($"Покупаемые продукты не соответствуют продаваемым");
        }

        decimal totalAmount = 0;
        
        foreach (var product in salesPointProducts)
        {
            var price = (product.Product.Price * product.Quantity);
            var productInPoint = salesPoint.ProvidedProducts.FirstOrDefault(x => x.ProductId == product.ProductId);
            productInPoint.Quantity -= product.Quantity;
            totalAmount += price;
        }

        if (money < totalAmount)
        {
            throw new Exception();
        }
        
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}