using System.Data;
using D2.Infrastructure.Contexts.SqlQueries.PostgreSql;
using D2.Infrastructure.Contexts.SqlQueries.SqliteQueries;
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
        // Create Tables
        var npgsqlConnection = await _connectionFactory.CreateConnection();
        var sqliteConnection = await _connectionFactorySqlite.CreateConnection();
        await CreateSeedTables(npgsqlConnection);
        await AddType<DamageTypeEntity>(sqliteConnection, npgsqlConnection, SelectQueries.DamageTypes,
            InsertQueries.InsertDamageTypes);
        await AddType<LoreEntity>(sqliteConnection, npgsqlConnection, SelectQueries.Lore, InsertQueries.InsertLore);
        await AddType<SocketCategory>(sqliteConnection, npgsqlConnection, SelectQueries.SocketCategories,
            InsertQueries.InsertSocketCategories);
        await AddType<Socket>(sqliteConnection, npgsqlConnection, SelectQueries.Sockets, InsertQueries.InsertSockets);
        await AddType<StatDefinition>(sqliteConnection, npgsqlConnection, SelectQueries.StatDefinitions,
            InsertQueries.InsertStatDefinitions);
        await AddType<ItemDefinition>(sqliteConnection, npgsqlConnection, SelectQueries.SelectItemDefinitions,
            InsertQueries.InsertItemDefinitions);
    }

    private static async Task CreateSeedTables(IDbConnection connection)
    {
        using var transaction = connection.BeginTransaction();
        try
        {
            await connection.ExecuteAsync(CreateTables.DropAllTables, transaction);
            await connection.ExecuteAsync(CreateTables.DamageTypes, transaction);
            await connection.ExecuteAsync(CreateTables.Lore, transaction);
            await connection.ExecuteAsync(CreateTables.Sockets, transaction);
            await connection.ExecuteAsync(CreateTables.StatDefinitions, transaction);
            await connection.ExecuteAsync(CreateTables.SocketCategories, transaction);
            await connection.ExecuteAsync(CreateTables.ItemDefinitions, transaction);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }
        finally
        {
            transaction.Commit();
        }
    }

    private static async Task AddType<T>(IDbConnection sqliteConnection, IDbConnection npgSqlConnection, string q1,
        string q2) where T : class
    {
        var damageTypes = (await sqliteConnection.QueryAsync<T>(q1)).ToList();
        var transaction = npgSqlConnection.BeginTransaction();
        try
        {
            await npgSqlConnection.ExecuteAsync(q2, damageTypes, transaction);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }
        finally
        {
            transaction.Commit();
        }
    }
}

public class DamageTypeEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Alpha { get; set; }
}

public class LoreEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
}

public class SocketCategory
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class Socket
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SocketType { get; set; } = string.Empty;
}

public class StatDefinition
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class ItemDefinition
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string IconWatermarks { get; set; } = string.Empty;
    public string Screenshot { get; set; } = string.Empty;
    public string TierType { get; set; } = string.Empty;
    public string FlavorText { get; set; } = string.Empty;
    public int ItemType { get; set; }
    public int ItemSubType { get; set; }
    public long? LoreId { get; set; }
    public long? DamageTypeId { get; set; }
}