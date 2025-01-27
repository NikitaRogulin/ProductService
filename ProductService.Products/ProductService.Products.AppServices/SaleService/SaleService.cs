using ProductService.Products.Domain;
using ProductService.Products.Domain.Models;

namespace ProductService.Products.AppServices.SaleService;

public class SaleService : ISaleService
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<long> Create(long id, DateTime dateSale, long salesPointId, long productId, Product product,
        SalesPoint salesPoint, int productQuantity, CancellationToken cancellationToken = default)
    {
        var _salesPoint = await _unitOfWork.SalesPointRepository.GetById(salesPointId, cancellationToken);
        if (_salesPoint == null)
        {
            throw new InvalidOperationException("Не удалось получить точку продажи для создания акта продажи");
        }

        var providedProducts = _salesPoint.ProvidedProducts.FirstOrDefault(x=> x.ProductId == productId);
        if (providedProducts.Quantity < productQuantity)
        {
            throw new InvalidOperationException("Недостаточное количество продуктов для продавжи");
        }

        providedProducts.Quantity -= productQuantity;

        var sale = new Sale()
        {
            Id = id,
            DateSale = dateSale,
            Product = null,
            ProductAmount = product.Price * productQuantity,
            SalesPoint = _salesPoint,
            SalesPointId = _salesPoint.Id,
            ProductQuantity = productQuantity,
            ProductId = productId
        };
        _unitOfWork.SalesPointRepository.Update(_salesPoint);
        _unitOfWork.SaleRepository.Create(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
        return sale.Id;
    }

    public async Task<Sale> GetById(long id, CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new InvalidOperationException($"Не удалось получить продажу по такому id - {id}");
        }
        return sale;
    }

    public async Task Update(long id, DateTime dateTime, long salesPointId, long productId, Product product,
        SalesPoint salesPoint, int productQuantity, CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new InvalidOperationException($"Не удалось обновить продажу с таким id - {id}");
        }

        sale.DateSale = dateTime;
        sale.SalesPointId = salesPointId;
        sale.ProductId = productId;
        sale.Product = product;
        sale.SalesPoint = salesPoint;
        sale.ProductQuantity = productQuantity;
        
        _unitOfWork.SaleRepository.Update(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Delete(long id, CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new InvalidOperationException($"Не удалось удалить продажу с таким id -{id}");
        }
        _unitOfWork.SaleRepository.Delete(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}