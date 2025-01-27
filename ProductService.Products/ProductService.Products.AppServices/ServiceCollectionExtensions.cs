using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Products.AppServices.ProductService;
using ProductService.Products.AppServices.SaleService;
using ProductService.Products.AppServices.SalesPointService;

namespace ProductService.Products.AppServices;


public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService.ProductService>();
        serviceCollection.AddScoped<ISaleService, SaleService.SaleService>();
        serviceCollection.AddScoped<ISalesPointService, SalesPointService.SalesPointService>();
    }
}