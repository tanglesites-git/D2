using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace D2.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:NpgsqlDefaultConnection"]!;
        services.AddDatabase(connectionString);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionNpgsqlFactory>(_ => new NpsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}

public interface IDbConnectionNpgsqlFactory
{
    Task<IDbConnection> CreateConnection();
}

public class NpsqlConnectionFactory : IDbConnectionNpgsqlFactory
{
    private readonly string _connectionString;

    public NpsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}


public class DbInitializer
{
    private readonly IDbConnectionNpgsqlFactory _connectionFactory;

    public DbInitializer(IDbConnectionNpgsqlFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Initialize()
    {
        using var connection = await _connectionFactory.CreateConnection();
        const string sql = "CREATE TABLE IF NOT EXISTS test_table (id serial PRIMARY KEY, name VARCHAR(50))";
        await connection.ExecuteAsync(sql);
    }
}