using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public interface ISalesPointService
{
    public Task<Guid> Create(string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales, CancellationToken cancellationToken = default);
    public Task<SalesPoint> GetById(Guid id, CancellationToken cancellationToken = default);

    public Task Update(Guid id, string name, ICollection<SalesPointProduct> providedProducts, ICollection<Sale> sales, CancellationToken cancellationToken = default);

    public Task Delete(Guid id, CancellationToken cancellationToken = default);

    public Task Sell(Guid salesPointId, List<SalesPointProduct> salesPointProducts,  decimal money, CancellationToken cancellationToken = default );
}