using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Products.Domain;
using ProductService.Products.Domain.IRepository;
using ProductService.Products.Persistence.Repositories;

namespace ProductService.Products.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        
        services.AddDbContext<ProductsContext>(options =>
            options.UseInMemoryDatabase("ProductsInMemoryDb"));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISalesPointRepository, SalesPointRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}