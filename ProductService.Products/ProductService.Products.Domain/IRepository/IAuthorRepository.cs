using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.Domain.IRepository;

public interface IAuthorRepository
{
    public void GetModels(List<Product> products, List<Sale> sales, List<SalesPoint> salesPoints);
}