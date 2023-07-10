using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MyCompany.MyFunctions;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureHostConfiguration(configuration =>
    {
        List<KeyValuePair<string, string>> myInMemoryConfigs = new()
            {
                new KeyValuePair<string, string>("MyConfigKey", "MyConfigValue")
            };

        configuration.AddInMemoryCollection(myInMemoryConfigs);
    })
    .ConfigureServices(services =>
    {
        services.AddTransient<IMyInterface, MyService>();
    });

var host = builder.Build();

await host.RunAsync();