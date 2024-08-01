using System.Text.Json.Serialization;

namespace D2.Core.Domain.Entities;

public class ManifestMobileWorldContentPaths : Localization<string>
{
    
}


[JsonSerializable(typeof(ManifestMobileWorldContentPaths))]
public partial class ManifestMobileWorldContentPathsSerializableContext : JsonSerializerContext
{
}