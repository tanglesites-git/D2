using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace D2.Staging.WebApi.Extensions;

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