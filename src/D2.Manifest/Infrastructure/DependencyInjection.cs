using D2.Manifest.Application;
using D2.Manifest.Kernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2.Manifest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var bungieConfig = configuration.GetSection(Bungie.Section).Get<Bungie>();
        var databaseConfig = configuration.GetSection(ConnectionStrings.Section).Get<ConnectionStrings>();
        services.AddHttpClient("ManifestClient", ConfigureClient(bungieConfig));
        services.AddScopedServices();
        return services;
    }
    
    private static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddSingleton<IManifestApp, ManifestApp>();
        services.AddScoped<IManifestHttpClient, ManifestHttpClient>();
        services.AddScoped<IManifestIOClient, ManifestIOClient>();
        return services;
    }

    private static Action<HttpClient> ConfigureClient(Bungie? config)
    {
        return httpClient =>
        {
            httpClient.BaseAddress = new Uri(config?.BaseAddress ?? throw new ArgumentNullException(nameof(config)));
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.DefaultRequestHeaders.Add("X-API-Key", config.ApiKey);
        };
    }
}



