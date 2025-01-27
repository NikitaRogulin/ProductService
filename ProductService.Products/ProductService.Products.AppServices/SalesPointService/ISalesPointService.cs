using ProductService.Products.Domain.Models;

namespace ProductService.Products.AppServices.SalesPointService;

public interface ISalesPointService
{
    public Task<long> Create(long id, string name, List<SalesPointProduct> providedProducts, List<Sale> sales, CancellationToken cancellationToken = default);
    public Task<SalesPoint> GetById(long id, CancellationToken cancellationToken = default);

    public Task Update(long id, string name, List<SalesPointProduct> providedProducts, List<Sale> sales, CancellationToken cancellationToken = default);

    public Task Delete(long id, CancellationToken cancellationToken = default);
}