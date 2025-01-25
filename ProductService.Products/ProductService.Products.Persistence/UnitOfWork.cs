using ProductService.Products.Domain;
using ProductService.Products.Domain.IRepository;
using ProductService.Products.Persistence.Repositories;

namespace ProductService.Products.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsContext _productsContext;
    
    public IProductRepository ProductRepository { get; }
    public ISaleRepository SaleRepository { get; }
    public ISalesPointRepository SalesPointRepository { get; }

    public UnitOfWork(ProductsContext context, ProductRepository productRepository, SaleRepository saleRepository, SalesPointRepository salesPointRepository)
    {
        _productsContext = context;
        ProductRepository = productRepository;
        SaleRepository = saleRepository;
        SalesPointRepository = salesPointRepository;
    }
    
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _productsContext.SaveChangesAsync(cancellationToken);
    }
}