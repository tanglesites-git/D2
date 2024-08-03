using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public record InvestmentStatsItem
{
    [JsonPropertyName("statTypeHash")]
    public uint StatTypeHash { get; set; }
    
    [JsonPropertyName("value")]
    public int Value { get; set; }
}