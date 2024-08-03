using System.Text.Json.Serialization;

namespace D2.Domain.InventoryItemDefinition;

public class EquippingBlock
{
    [JsonPropertyName("equipmentSlotTypeHash")]
    public uint EquipmentSlotTypeHash { get; set; }
    
    [JsonPropertyName("ammoType")]
    public int AmmoType { get; set; }
}