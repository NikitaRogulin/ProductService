using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Domain.IRepository;

public interface ISaleRepository
{
    public void Create(Sale sale);
    public ValueTask<Sale?> GetById(long id, CancellationToken cancellationToken = default);
    public void Update(Sale sale);
    public void Delete(Sale sale);
}