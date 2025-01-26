using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface ISaleService
{
    public Task<long> Create(long id, DateTime dateTime, long salesPointId, ICollection<SaleProduct> salesData, CancellationToken cancellationToken = default);
    public Task<Sale> GetById(long id, CancellationToken cancellationToken = default);

    public Task Update(long id, DateTime dateTime, long salesPointId, ICollection<SaleProduct> salesData,
        CancellationToken cancellationToken = default);

    public Task Delete(long id, CancellationToken cancellationToken = default);
}