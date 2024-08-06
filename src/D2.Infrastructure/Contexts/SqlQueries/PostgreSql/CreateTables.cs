namespace D2.Infrastructure.Contexts.SqlQueries.PostgreSql;

public class CreateTables
{
    public const string DropAllTables = @"
        DROP TABLE IF EXISTS ItemDefinitions;
        DROP TABLE IF EXISTS Sockets;
        DROP TABLE IF EXISTS SocketCategories;
        DROP TABLE IF EXISTS Lore;
        DROP TABLE IF EXISTS StatDefinitions;
        DROP TABLE IF EXISTS DamageTypes;
    ";

    public const string DamageTypes = @"
        CREATE TABLE IF NOT EXISTS DamageTypes (
            Id bigint not null ,
            Name varchar(255) not null ,
            Description text not null ,
            Icon varchar(255) ,
            Red int not null default 0,
            Green int not null default 0 ,
            Blue int not null default 0 ,
            Alpha int not null default 0 ,
            PRIMARY KEY (Id)
        );
    ";


    public const string StatDefinitions = @"
        CREATE TABLE IF NOT EXISTS StatDefinitions (
            Id bigint not null ,
            Name varchar(255) not null ,
            Description text not null ,
            Icon varchar(255) ,
            PRIMARY KEY (Id)
        );
    ";

    public const string Lore = @"
        CREATE TABLE IF NOT EXISTS Lore (
            Id bigint not null ,
            Name varchar(255) not null default '',
            Description text not null default '',
            Icon varchar(255) not null default '',
            Subtitle text not null default '',
            PRIMARY KEY (Id)
        );
    ";

    public const string SocketCategories = @"
        CREATE TABLE IF NOT EXISTS SocketCategories (
            Id bigint not null ,
            Name varchar(255) not null ,
            Description text not null ,
            PRIMARY KEY (Id)
        );
    ";

    public const string Sockets = """
                                  CREATE TABLE IF NOT EXISTS Sockets (
                                      Id bigint not null ,
                                      Name varchar(255) not null ,
                                      Description text not null ,
                                      SocketType varchar(255) not null ,
                                      PRIMARY KEY (Id)
                                  );
                                  """;

    public const string ItemDefinitions = @"
        CREATE TABLE IF NOT EXISTS ItemDefinitions
        (
            Id           bigint       not null,
            Name         varchar(255) not null,
            Description  text         not null,
            Icon         varchar(255) not null,
            DisplayName  varchar(255) not null,
            IconWatermark varchar(255) not null,
            Screenshot  varchar(255) not null,
            FlavorText  text not null,
            TierType     varchar(255) not null,
            ItemType     int not null ,
            ItemSubType  int not null ,
            LoreId       bigint references Lore (Id) null default null, 
            DamageTypeId bigint references DamageTypes (Id) null default null,
            CONSTRAINT PK_ITEM_DEFINITIONS PRIMARY KEY (Id)
        );
    ";
}