using System.Data;
using Npgsql;

namespace D2.Infrastructure.Contexts;


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