using System.Text.Json.Serialization;

namespace D2.Core.Domain.Entities;

public class ManifestResponse
{
    [JsonPropertyName("version")]
    public string? Version { get; set; }
    [JsonPropertyName("mobileAssetContentPath")]
    public ManifestMobileWorldContentPaths MobileWorldContentPaths { get; set; } = new();
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public ManifestJsonWorldComponentContentPaths JsonWorldComponentContentPaths { get; set; } = new();
}


[JsonSerializable(typeof(ManifestResponse))]
public partial class ManifestResponseSerializableContext : JsonSerializerContext
{
}