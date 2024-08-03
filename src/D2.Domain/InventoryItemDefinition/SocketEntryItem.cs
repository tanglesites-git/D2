using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public record SocketEntryItem
{
    [JsonPropertyName("socketTypeHash")] public uint SocketTypeHash { get; set; }
    
    [JsonPropertyName("singleInitialItemHash")] public uint SingleInitialItemHash { get; set; }
    
    [JsonPropertyName("reusablePlugSetHash")] public uint ReusablePlugSetHash { get; set; }
    
    [JsonPropertyName("randomizedPlugSetHash")] public uint RandomizedPlugSetHash { get; set; }
}