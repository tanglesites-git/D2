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

    public const string Sockets = @"
        with cte as (select json -> 'hash'                        as Id,
                    json -> 'displayProperties' ->> 'name'        as Name,
                    json -> 'displayProperties' ->> 'description' as Description,
                    json -> 'displayProperties' ->> 'icon'        as Icon,
                    json ->> 'itemTypeDisplayName'                as DisplayName,
                    json -> 'inventory' ->> 'tierTypeName'        as TierType
             from DestinyInventoryItemDefinition
             where json -> 'inventory' ->> 'tierTypeName' is not null
             order by DisplayName)
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Scope'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Magazine'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Stock'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Launcher Barrel'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Grip'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Trait'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Blade'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Enhanced Trait'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Origin Trait'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Intrinsic'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Enhanced Intrinsic'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Guard'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Battery'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Stock'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Bowstring'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Haft'
                union
                select Id, Name, DisplayName, TierType, Description
                from cte
                where DisplayName = 'Arrow'
                group by DisplayName, Id, Name
                order by DisplayName;
    ";

    public const string SelectItemDefinitions = @"
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
    from DestinyInventoryItemDefinition;
    ";
}