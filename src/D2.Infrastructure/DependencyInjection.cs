using System.Data;
using D2.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var npgsqlConnectionString = configuration["ConnectionStrings:NpgsqlDefaultConnection"]!;
        var sqliteConnectionString = configuration["ConnectionStrings:SqliteDefaultConnection"]!;
        services.AddSingleton<IDbConnectionNpgsqlFactory>(
            _ => new NpsqlConnectionFactory(npgsqlConnectionString)
            );
        services.AddSingleton<IDbConnectionSqliteFactory>(
            _ => new SqliteConnectionFactory(sqliteConnectionString)
            );
        services.AddSingleton<DbInitializer>();
        return services;
    }
}