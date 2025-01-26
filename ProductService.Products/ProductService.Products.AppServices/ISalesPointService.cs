using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface ISalesPointService
{
    public Task<long> Create(long id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales, CancellationToken cancellationToken = default);
    public Task<SalesPoint> GetById(long id, CancellationToken cancellationToken = default);

    public Task Update(long id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales, CancellationToken cancellationToken = default);

    public Task Delete(long id, CancellationToken cancellationToken = default);

    public Task Sell(long salesPointId, List<SalesPointProduct> salesPointProducts,  decimal money, CancellationToken cancellationToken = default );
}