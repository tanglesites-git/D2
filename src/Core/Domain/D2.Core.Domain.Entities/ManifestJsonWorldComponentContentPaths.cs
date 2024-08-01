using System.Text.Json.Serialization;

namespace D2.Core.Domain.Entities;

public class ManifestJsonWorldComponentContentPaths : Localization<DestinyTables>
{
    
}


[JsonSerializable(typeof(ManifestJsonWorldComponentContentPaths))]
public partial class ManifestJsonWorldComponentContentPathsSerializableContext : JsonSerializerContext
{
}