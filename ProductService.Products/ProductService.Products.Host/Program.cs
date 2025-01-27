using ProductService.Products.Host;

var host = HostBuilderFactory<Startup>.CreateHostBuilder(args).Build();

await host.RunAsync();