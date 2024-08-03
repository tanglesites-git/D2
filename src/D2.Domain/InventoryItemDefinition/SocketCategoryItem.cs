using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public record SocketCategoryItem
{
    [JsonPropertyName("socketCategoryHash")] public uint SocketCategoryHash { get; set; }
    
    [JsonPropertyName("socketIndexes")] public List<int> SocketIndexes { get; set; } = new();
}