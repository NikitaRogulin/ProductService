using ProductService.Products.Domain.Models;

namespace ProductService.Products.AppServices.SaleService;

public interface ISaleService
{
    public Task<long> Create(long id, DateTime dateSale, long salesPointId, long productId, Product product,
        SalesPoint salesPoint, int productQuantity, CancellationToken cancellationToken = default);

    public Task<Sale> GetById(long id, CancellationToken cancellationToken = default);

    public Task Update(long id, DateTime dateTime, long salesPointId, long productId, Product product,
        SalesPoint salesPoint, int productQuantity, CancellationToken cancellationToken = default);

    public Task Delete(long id, CancellationToken cancellationToken = default);
}