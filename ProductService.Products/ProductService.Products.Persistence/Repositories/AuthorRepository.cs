using Microsoft.EntityFrameworkCore;
using ProductService.Products.Domain.Contracts.Models;
using ProductService.Products.Domain.IRepository;
using ProductService.Products.AppServices;

namespace ProductService.Products.Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public AuthorRepository()
    {
        using (var context = new ProductsContext())
        {
            var products = new List<Product>
            {
                new Product(1,"Молоко", 73),
                new Product(2,"Хлеб", 56),
                new Product(3,"Яйца", 140),
                new Product(4,"Мясо", 440),
                new Product(5,"Напиток", 110),
                new Product(6,"Конфета", 11)
            };

            var sales = new List<Sale>()
            {
                new Sale(1, new DateTime(2022, 5, 10), 1,
                    new List<SaleProduct>()
                    {
                        new SaleProduct(1, null, products[1].Id, products[1], 1),
                        new SaleProduct(1, null, products[2].Id,products[2], 2)
                    }),
                new Sale(2, new DateTime(2023, 4, 9), 1,
                    new List<SaleProduct>()
                    {
                        new SaleProduct(2, null, products[5].Id, products[5], 1)
                    }),
                new Sale(3, new DateTime(2024, 11, 23), 2,
                    new List<SaleProduct>()
                    {
                        new SaleProduct(Guid.NewGuid(), null, Guid.NewGuid(), products[3], 2),
                        new SaleProduct(Guid.NewGuid(), null, Guid.NewGuid(), products[4], 2),
                    }),
            };
            
            var providedProducts = new List<SalesPointProduct>()
            {
                new SalesPointProduct(null, null, products[0].Id, 5),
                
            }
            
            var salesPoint = new SalesPoint(Guid.NewGuid(), "Лента", null,  )
        }
        
    
    public void GetModels(List<Product> products, List<Sale> sales, List<SalesPoint> salesPoints)
    {
        
    }
}