using System.Text.Json.Serialization;

namespace D2.Domain.Manifest;

public class ManifestJsonWorldComponentContentPaths : Localization<DestinyTables>
{
    
}


[JsonSerializable(typeof(ManifestJsonWorldComponentContentPaths))]
public partial class ManifestJsonWorldComponentContentPathsSerializableContext : JsonSerializerContext
{
}