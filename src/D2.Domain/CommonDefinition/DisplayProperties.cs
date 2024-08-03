using System.Text.Json.Serialization;

namespace D2.Domain.CommonDefinition;

public class DisplayProperties
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }
    
    [JsonPropertyName("hasIcon")]
    public bool HasIcon { get; set; }
    
    [JsonPropertyName("highResIcon")]
    public string? HighResIcon { get; set; }
    
    [JsonPropertyName("iconSequences")]
    public List<IconSequenceItem>? IconSequences { get; set; } = new();
}

public record IconSequenceItem
{
    [JsonPropertyName("frames")]
    public List<string>? Frames { get; set; } = new();
}