namespace D2.Infrastructure.Contexts;

public static class D2DataLakeSQLQueries
{

    public static string DropAllTables()
    {
        return @"

        DROP TABLE IF EXISTS ItemTypeDisplayName;";
    }
    public static string CreateItemTypeDisplayNameTableSQL()
    {
        return @"
        CREATE TABLE IF NOT EXISTS ItemTypeDisplayName (
            id serial PRIMARY KEY,
            itemTypeDisplayName VARCHAR(50)
        );
    ";
    }

    public static string SelectAllItemTypeDisplayNamesSQL()
    {
        return $"""
                
                        select distinct 
                            json ->> 'itemTypeDisplayName' as itemTypeDisplayName
                        from DestinyInventoryItemDefinition where itemTypeDisplayName != "" order by itemTypeDisplayName;
                """;
    }

    public static string InsertItemTypeDisplayNameSQL()
    {
        return @"INSERT INTO ItemTypeDisplayName (itemTypeDisplayName) VALUES (@itemTypeDisplayName)";
    }
}