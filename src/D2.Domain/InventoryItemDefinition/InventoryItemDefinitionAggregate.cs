using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.InventoryItemDefinition;

public class InventoryItemDefinitionAggregate
{
    [JsonPropertyName("hash")] public uint Hash { get; set; }
    
    [JsonPropertyName("displayProperties")]
    public DisplayProperties DisplayProperties { get; set; } = new();

    [JsonPropertyName("iconWatermark")] public string? IconWatermark { get; set; }

    [JsonPropertyName("screenshot")] public string? Screenshot { get; set; }

    [JsonPropertyName("itemTypeDisplayName")]
    public string? ItemTypeDisplayName { get; set; }

    [JsonPropertyName("flavorText")] public string? FlavorText { get; set; }

    [JsonPropertyName("collectibleHash")] public uint CollectibleHash { get; set; }

    [JsonPropertyName("investmentStats")] public List<InvestmentStatsItem> InvestmentStats { get; set; } = new();

    [JsonPropertyName("inventory")] public Inventory Inventory { get; set; } = new();

    [JsonPropertyName("equippingBlock")] public EquippingBlock EquippingBlock { get; set; } = new();

    [JsonPropertyName("defaultDamageTypeHash")]
    public uint DefaultDamageTypeHash { get; set; }
    
    [JsonPropertyName("sockets")] public Sockets Sockets { get; set; } = new();
}