select distinct json ->> 'itemTypeDisplayName' as DisplayName,
                json -> 'itemType'             as ItemType,
                json -> 'itemSubType'          as ItemSubType
from DestinyInventoryItemDefinition
where json ->> 'itemType' == 19
  and json ->> 'itemSubType' != 21
  and json ->> 'itemSubType' != 20;

-- Get All Inventory Items

select json -> 'hash'                                as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       json -> 'displayProperties' ->> 'icon'        as Icon,
       json -> 'itemTypeDisplayName'                 as DisplayName,
       json -> 'inventory' -> 'tierTypeName'         as TierType,
       json -> 'itemType'                            as ItemType,
       json -> 'itemSubType'                         as ItemSubType,
       json -> 'loreHash'                            as LoreId,
       json -> 'defaultDamageTypeHash'               as DamageTypeId
from DestinyInventoryItemDefinition
where json -> 'inventory' ->> 'tierTypeName' is not null
order by ItemType;

-- Get All Damage Types

select json -> 'hash'                                as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       json -> 'displayProperties' ->> 'icon'        as Icon,
       json -> 'color' ->> 'red'                     as Red,
       json -> 'color' ->> 'green'                   as Green,
       json -> 'color' ->> 'blue'                    as Blue,
       json -> 'color' ->> 'alpha'                   as Alpha
from DestinyDamageTypeDefinition;


-- Get All Stat Definitions
select json -> 'hash'                                as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       json -> 'displayProperties' ->> 'icon'        as Icon
from DestinyStatDefinition;


-- Get All Lore

select json -> 'hash'                                as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       json -> 'displayProperties' ->> 'icon'        as Icon,
       json ->> 'subtitle'                           as Subtitle
from DestinyLoreDefinition;


-- Get Socket Categories

select json -> 'hash'                                as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description
from DestinySocketCategoryDefinition
where json -> 'displayProperties' ->> 'name' != ""
  and json -> 'displayProperties' ->> 'description' != "";


-- Perks

with cte as (select json -> 'hash'                                as Id,
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