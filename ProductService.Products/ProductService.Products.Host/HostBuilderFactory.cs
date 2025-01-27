namespace ProductService.Products.Host;

public class HostBuilderFactory<TStartup> where TStartup : class
{
    public static IHostBuilder CreateHostBuilder(string[] args, string? baseDirectory = null)
    {
        var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(host => { host.UseStartup<TStartup>(); });
        return builder;
    }
}