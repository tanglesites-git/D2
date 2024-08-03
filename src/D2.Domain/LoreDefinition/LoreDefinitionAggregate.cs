using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.LoreDefinition;

public class LoreDefinitionAggregate
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    [JsonPropertyName("displayProperties")]
    public DisplayProperties? DisplayProperties { get; set; } = new();
    
    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }
}