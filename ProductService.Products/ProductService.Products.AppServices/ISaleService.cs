using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface ISaleService
{
    public Task<Guid> Create(DateTime dateTime, Guid salesPointId, ICollection<SaleProduct> salesData, CancellationToken cancellationToken = default);
    public Task<Sale> GetById(Guid id, CancellationToken cancellationToken = default);

    public Task Update(Guid id, DateTime dateTime, Guid salesPointId, ICollection<SaleProduct> salesData,
        CancellationToken cancellationToken = default);

    public Task Delete(Guid id, CancellationToken cancellationToken = default);
}