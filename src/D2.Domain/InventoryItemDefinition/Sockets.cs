using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public class Sockets
{
    [JsonPropertyName("socketEntries")] public List<SocketEntryItem> SocketEntries { get; set; } = new();
    
    [JsonPropertyName("socketCategories")] public List<SocketCategoryItem> SocketCategories { get; set; } = new();
}