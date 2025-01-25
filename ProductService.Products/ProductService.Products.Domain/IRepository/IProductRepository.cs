using ProductService.Products.Domain.Contracts.Models;
namespace ProductService.Products.Domain.IRepository;

public interface IProductRepository
{
    public void Create(Product product);
    public ValueTask<Product?> GetById(Guid id, CancellationToken cancellationToken = default);
    public void Update(Product product);
    public void Delete(Product product);

}