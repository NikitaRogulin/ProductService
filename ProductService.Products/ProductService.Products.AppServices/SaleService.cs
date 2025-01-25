using ProductService.Products.Domain;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public class SaleService : ISaleService
{
    private readonly IUnitOfWork _unitOfWork;

    public SaleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Create(DateTime dateTime, Guid salesPointId, ICollection<SaleProduct> salesData, CancellationToken cancellationToken = default)
    {
        var sale = new Sale(Guid.NewGuid(), dateTime, salesPointId, salesData);
        _unitOfWork.SaleRepository.Create(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
        return sale.Id;
    }

    public async Task<Sale> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new Exception($"Не удалось получить продажу по такому id - {id}");
        }
        return sale;
    }

    public async Task Update(Guid id, DateTime dateTime, Guid salesPointId, ICollection<SaleProduct> salesData,
        CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new Exception($"Не удалось обновить продажу с таким id - {id}");
        }

        sale.Date = dateTime;
        sale.SalesPointId = salesPointId;
        sale.SalesData = salesData;
        
        _unitOfWork.SaleRepository.Update(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await _unitOfWork.SaleRepository.GetById(id, cancellationToken);
        if (sale == null)
        {
            throw new Exception($"Не удалось удалить продажу с таким id -{id}");
        }
        _unitOfWork.SaleRepository.Delete(sale);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}