using Dapper;

namespace D2.Infrastructure.Contexts;

public class DbInitializer
{
    private readonly IDbConnectionNpgsqlFactory _connectionFactory;
    private readonly IDbConnectionSqliteFactory _connectionFactorySqlite;

    public DbInitializer(IDbConnectionNpgsqlFactory connectionFactory,
        IDbConnectionSqliteFactory connectionFactorySqlite)
    {
        _connectionFactory = connectionFactory;
        _connectionFactorySqlite = connectionFactorySqlite;
    }

    public async Task Initialize()
    {
        // sqlite
        using var sqliteConnection = await _connectionFactorySqlite.CreateConnection();
        var items =
            await sqliteConnection.QueryAsync<ItemTypeDisplayNameEntity>(D2DataLakeSQLQueries
                .SelectAllItemTypeDisplayNamesSQL());
        
        // npgsql
        using var connection = await _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(D2DataLakeSQLQueries.DropAllTables());
        await connection.ExecuteAsync(D2DataLakeSQLQueries.CreateItemTypeDisplayNameTableSQL());

        foreach (var item in items)
        {
            await connection.ExecuteAsync(D2DataLakeSQLQueries.InsertItemTypeDisplayNameSQL(), item);
        }
    }
}

public class ItemTypeDisplayNameEntity
{
    public decimal Id { get; set; }
    public string ItemTypeDisplayName { get; set; } = string.Empty;
}