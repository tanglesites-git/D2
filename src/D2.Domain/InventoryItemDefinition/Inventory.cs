using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public class Inventory
{
    [JsonPropertyName("tierTypeName")]
    public string? TierTypeName { get; set; }
}