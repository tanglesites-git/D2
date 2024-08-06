namespace D2.Infrastructure.Contexts.SqlQueries.PostgreSql;

public class InsertQueries
{
    public const string InsertDamageTypes = @"INSERT INTO damagetypes VALUES (@Id, @Name, @Description, @Icon, @Red, @Green, @Blue, @Alpha)";
    public const string InsertLore = @"INSERT INTO lore VALUES (@Id, @Name, @Description, @Icon, @Subtitle)";
    public const string InsertStatDefinitions = @"INSERT INTO statdefinitions VALUES (@Id, @Name, @Description, @Icon)";
    public const string InsertSocketCategories = @"INSERT INTO socketcategories VALUES (@Id, @Name, @Description)";
    public const string InsertSockets = @"INSERT INTO sockets VALUES (@Id, @Name, @Description, @SocketType)";
    public const string InsertItemDefinitions = @"INSERT INTO itemdefinitions VALUES 
                                (@Id, @Name, @Description, @Icon, @DisplayName, @IconWatermarks, @Screenshot, @FlavorText, @TierType, @ItemType, @ItemSubType, @LoreId, @DamageTypeId)";
}