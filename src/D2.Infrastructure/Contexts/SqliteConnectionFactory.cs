using System.Data;
using System.Data.SQLite;

namespace D2.Infrastructure.Contexts;


public interface IDbConnectionSqliteFactory
{
    Task<IDbConnection> CreateConnection();
}


public class SqliteConnectionFactory : IDbConnectionSqliteFactory
{
    private readonly string _connectionString;

    public SqliteConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnection()
    {
        var connection = new SQLiteConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}