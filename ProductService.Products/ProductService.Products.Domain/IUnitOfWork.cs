using ProductService.Products.Domain.IRepository;

namespace ProductService.Products.Domain;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ISaleRepository SaleRepository { get; }
    public ISalesPointRepository SalesPointRepository { get; }

    public Task CommitAsync(CancellationToken cancellationToken = default);
}