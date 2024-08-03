using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.CollectibleDefinition;

public class CollectibleAggregate
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }
    [JsonPropertyName("displayProperties")]
    public DisplayProperties DisplayProperties { get; set; } = new();
    [JsonPropertyName("sourceString")]
    public string? SourceString { get; set; }
}