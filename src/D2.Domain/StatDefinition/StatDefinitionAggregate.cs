using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.StatDefinition;

public class StatDefinitionAggregate
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }
    
    [JsonPropertyName("displayProperties")]
    public DisplayProperties DisplayProperties { get; set; } = new();
}