using System.Text.Json.Serialization;

namespace D2.Manifest.Domain;

[JsonSerializable(typeof(ManifestRoot))]
public partial class ManifestRootContext : JsonSerializerContext
{
    
}


[JsonSerializable(typeof(ManifestResponse))]
public partial class ManifestResponseContext : JsonSerializerContext
{
    
}