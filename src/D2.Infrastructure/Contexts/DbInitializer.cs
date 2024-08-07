using System.Data;
using System.Diagnostics;
using D2.Application.DTO;
using D2.Infrastructure.Contexts.SqlQueries.PostgreSql;
using D2.Infrastructure.Contexts.SqlQueries.SqliteQueries;
using Dapper;

namespace D2.Infrastructure.Contexts
{
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
            var startCreateSeedTables = Stopwatch.GetTimestamp();
            await CreateSeedTables(npgsqlConnection);
            var endCreateSeedTables = Stopwatch.GetTimestamp();

            var startDamageTypes = Stopwatch.GetTimestamp();
            await AddType<DamageTypeEntity>(sqliteConnection, npgsqlConnection, SelectQueries.DamageTypes,
                InsertQueries.InsertDamageTypes);
            var endDamageTypes = Stopwatch.GetTimestamp();
            
            var startLore = Stopwatch.GetTimestamp();
            await AddType<LoreEntity>(sqliteConnection, npgsqlConnection, SelectQueries.Lore, InsertQueries.InsertLore);
            var endLore = Stopwatch.GetTimestamp();
            
            var startSocketCategories = Stopwatch.GetTimestamp();
            await AddType<SocketCategory>(sqliteConnection, npgsqlConnection, SelectQueries.SocketCategories,
                InsertQueries.InsertSocketCategories);
            var endSocketCategories = Stopwatch.GetTimestamp();
            
            var startSockets = Stopwatch.GetTimestamp();
            await AddType<Socket>(sqliteConnection, npgsqlConnection, SelectQueries.Sockets, InsertQueries.InsertSockets);
            var endSockets = Stopwatch.GetTimestamp();
            
            var startStatDefinitions = Stopwatch.GetTimestamp();
            await AddType<StatDefinition>(sqliteConnection, npgsqlConnection, SelectQueries.StatDefinitions,
                InsertQueries.InsertStatDefinitions);
            var endStatDefinitions = Stopwatch.GetTimestamp();
            
            var startItemDefinitions = Stopwatch.GetTimestamp();
            await AddType<ItemDefinition>(sqliteConnection, npgsqlConnection, SelectQueries.SelectWeapons,
                InsertQueries.InsertItemDefinitions);
            var endItemDefinitions = Stopwatch.GetTimestamp();
            
            Console.WriteLine($"Create Seed Tables: {Stopwatch.GetElapsedTime(startCreateSeedTables, endCreateSeedTables)}ms");
            Console.WriteLine($"Damage Types: {Stopwatch.GetElapsedTime(startDamageTypes, endDamageTypes)}ms");
            Console.WriteLine($"Lore: {Stopwatch.GetElapsedTime(startLore, endLore)}ms");
            Console.WriteLine($"Socket Categories: {Stopwatch.GetElapsedTime(startSocketCategories, endSocketCategories)}ms");
            Console.WriteLine($"Sockets: {Stopwatch.GetElapsedTime(startSockets, endSockets)}ms");
            Console.WriteLine($"Stat Definitions: {Stopwatch.GetElapsedTime(startStatDefinitions, endStatDefinitions)}ms");
            Console.WriteLine($"Item Definitions: {Stopwatch.GetElapsedTime(startItemDefinitions, endItemDefinitions)}ms");
        }

        private static async Task CreateSeedTables(IDbConnection connection)
        {
            var transaction = connection.BeginTransaction();
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










}