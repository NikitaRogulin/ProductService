using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Domain.IRepository;

public interface ISalesPointRepository
{
    public void Create(SalesPoint salesPoint);
    public ValueTask<SalesPoint?> GetById(Guid id, CancellationToken cancellationToken = default);
    public void Update(SalesPoint salesPoint);
    public void Delete(SalesPoint salesPoint);
}