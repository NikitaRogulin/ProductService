using ProductService.Products.Domain;
using ProductService.Products.Domain.Contracts.Models;

namespace ProductService.Products.AppServices;

public class ProductService : IProductsService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Create(string name, decimal price, CancellationToken cancellationToken = default)
    {
        var product = new Product(Guid.NewGuid(), name, price);
        _unitOfWork.ProductRepository.Create(product);
        await _unitOfWork.CommitAsync(cancellationToken);
        return product.Id;
    }

    public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.ProductRepository.GetById(id, cancellationToken);
        if (product == null)
        {
            throw new Exception($"Не удалось получить продукт с такми id - {id}");
        }
        return product;
    }

    public async Task Update(Guid id, string name, decimal price, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.ProductRepository.GetById(id, cancellationToken);
        if (product == null)
        {
            throw new Exception($"Не удалось обновить продукт с таким id - {id}");
        }

        product.Name = name;
        product.Price = price;
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.ProductRepository.GetById(id, cancellationToken);
        if (product == null)
        {
            throw new Exception($"Не удалось удалить продукт с таким id -{id}");
        }
        _unitOfWork.ProductRepository.Delete(product);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}