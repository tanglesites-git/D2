namespace D2.Application.DTO;

public class ItemDefinition
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string IconWatermarks { get; set; } = string.Empty;
    public string Screenshot { get; set; } = string.Empty;
    public string TierType { get; set; } = string.Empty;
    public string FlavorText { get; set; } = string.Empty;
    public int ItemType { get; set; }
    public int ItemSubType { get; set; }
    public long? LoreId { get; set; }
    public long? DamageTypeId { get; set; }
}