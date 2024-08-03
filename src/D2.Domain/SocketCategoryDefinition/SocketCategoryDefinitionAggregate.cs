using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.SocketCategoryDefinition;

public class SocketCategoryDefinitionAggregate
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }
    
    [JsonPropertyName("displayProperties")]
    public DisplayProperties DisplayProperties { get; set; } = new();
}