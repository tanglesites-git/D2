# D2
A Destiny2 System

> In order to run the Aspire Dashboard run the command below:
```powershell
docker run --rm -it -p 18888:18888 -p 4317:18889 -d --name aspire-dashboard mcr.microsoft.com/dotnet/aspire-dashboard:8.0.0
```
> NOTE: You will need Docker Desktop installed on your machine.

### Add Your OTLP Configuration
```csharp
public static class OpenTelemetryExtensions
{
    public static IServiceCollection AddOpenTelemetryConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("D2.Staging.WebApi"))
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
                metrics.AddOtlpExporter(o => o.Endpoint = new Uri("http://localhost:4317"));
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
                // Add EfCoreInstrumentation
                tracing.AddOtlpExporter(o => o.Endpoint = new Uri("http://localhost:4317"));
            });
        builder.Logging.AddOpenTelemetry(logger =>
        {
            logger.AddOtlpExporter(o => o.Endpoint = new Uri("http://localhost:4317"));
            logger.IncludeScopes = true;
            logger.IncludeFormattedMessage = true;
        });
        return services;
    }
}
```

### Add Extension Method to your ServiceCollection
```csharp
public static class Destiny2ApplicationBuilder
{
    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        ...
        
        builder.Services.AddOpenTelemetryConfiguration(builder);
        
        ...
        return builder;
    }
    
    public static WebApplication BuildDestiny2(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        
        return app;
    }
}
```

> Lastly you should be able to run the Aspire Dashboard from within Docker Desktop.
