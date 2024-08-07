namespace D2.Infrastructure.Contexts.SqlQueries.SqliteQueries;

public class SelectQueries
{
    public const string DamageTypes = $"""
                                       select json -> 'hash'                                as Id,
                                              json -> 'displayProperties' ->> 'name'        as Name,
                                              json -> 'displayProperties' ->> 'description' as Description,
                                              json -> 'displayProperties' ->> 'icon'        as Icon,
                                              json -> 'color' ->> 'red'                     as Red,
                                              json -> 'color' ->> 'green'                   as Green,
                                              json -> 'color' ->> 'blue'                    as Blue,
                                              json -> 'color' ->> 'alpha'                   as Alpha
                                       from DestinyDamageTypeDefinition;
                                       """;

    public const string Lore = @"
        select json -> 'hash'                            as Id,
           json -> 'displayProperties' ->> 'name'        as Name,
           json -> 'displayProperties' ->> 'description' as Description,
           json -> 'displayProperties' ->> 'icon'        as Icon,
           json ->> 'subtitle'                           as Subtitle
        from DestinyLoreDefinition;
    ";

    public const string StatDefinitions = @"
        select json -> 'hash'                                as Id,
               json -> 'displayProperties' ->> 'name'        as Name,
               json -> 'displayProperties' ->> 'description' as Description,
               json -> 'displayProperties' ->> 'icon'        as Icon
        from DestinyStatDefinition;
    ";

    public const string SocketCategories = @"
        select json -> 'hash'                                as Id,
               json -> 'displayProperties' ->> 'name'        as Name,
               json -> 'displayProperties' ->> 'description' as Description
        from DestinySocketCategoryDefinition
        where json -> 'displayProperties' ->> 'name' != """"
          and json -> 'displayProperties' ->> 'description' != """";
    ";

    public const string SelectWeapons = @"
        select
            json -> 'hash' as Id,
            json -> 'displayProperties' ->> 'name' as Name,
            json -> 'displayProperties' ->> 'description' as Description,
            json -> 'displayProperties' ->> 'icon' as Icon,
            json ->> 'itemTypeDisplayName' as DisplayName,
            json ->> 'iconWatermark' as IconWatermark,
            json ->> 'screenshot' as Screenshot,
            json ->> 'flavorText' as FlavorText,
            json -> 'inventory' ->> 'tierTypeName' as TierType ,
            json ->> 'itemType' as ItemType,
            json ->> 'itemSubType' as ItemSubType,
            json ->> 'loreHash' as LoreId ,
            json ->> 'defaultDamageTypeHash' as DamageTypeId
    from DestinyInventoryItemDefinition where json ->> 'itemType'= 3;
    ";

    public const string Sockets = @"
        select json -> 'hash'                                as Id,
           json -> 'displayProperties' ->> 'name'        as Name,
           json -> 'displayProperties' ->> 'description' as Description,
           json -> 'displayProperties' ->> 'icon'        as Icon,
           json ->> 'itemTypeDisplayName'                as DisplayName,
           json -> 'inventory' ->> 'tierTypeName'        as TierType
        from DestinyInventoryItemDefinition
        where json ->> 'itemTypeDisplayName' = 'Armor'
           or json ->> 'itemTypeDisplayName' = 'Battery'
           or json ->> 'itemTypeDisplayName' = 'Blade'
           or json ->> 'itemTypeDisplayName' = 'Bowstring'
           or json ->> 'itemTypeDisplayName' = 'Enhanced Intrinsic'
           or json ->> 'itemTypeDisplayName' = 'Enhanced Trait'
           or json ->> 'itemTypeDisplayName' = 'Grip'
           or json ->> 'itemTypeDisplayName' = 'Guard'
           or json ->> 'itemTypeDisplayName' = 'Haft'
           or json ->> 'itemTypeDisplayName' = 'Intrinsic'
           or json ->> 'itemTypeDisplayName' = 'Launcher Barrel'
           or json ->> 'itemTypeDisplayName' = 'Magazine'
           or json ->> 'itemTypeDisplayName' = 'Origin Trait'
           or json ->> 'itemTypeDisplayName' = 'Scope'
           or json ->> 'itemTypeDisplayName' = 'Trait'
    ";
}