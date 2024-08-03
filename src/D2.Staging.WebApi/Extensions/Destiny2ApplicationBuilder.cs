using D2.Infrastructure;

namespace D2.Staging.WebApi.Extensions;

public static class Destiny2ApplicationBuilder
{
    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenTelemetryConfiguration(builder);
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfiguration();
        return builder;
    }

    public static WebApplication BuildDestiny2(this WebApplicationBuilder builder)
    {
        var app = builder.Build();
        app.UseSwaggerConfiguration();
        app.UseAuthorization();

        return app;
    }
}