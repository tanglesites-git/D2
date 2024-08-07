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

-- Get All Weapons
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
where json -> 'itemType' = 3
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


-- Sockets

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