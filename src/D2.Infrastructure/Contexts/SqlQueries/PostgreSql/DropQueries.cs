namespace D2.Infrastructure.Contexts.SqlQueries.PostgreSql;

public class DropQueries
{
    public const string DropAllTables = @"
        DROP TABLE IF EXISTS itemtypes;";
}