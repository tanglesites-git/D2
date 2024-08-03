using System.Text.Json.Serialization;
using D2.Domain.CommonDefinition;

namespace D2.Domain.DamageTypeDefinition;

public class DamageTypeDefinitionAggregate
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }
    [JsonPropertyName("displayProperties")]
    public DisplayProperties? DisplayProperties { get; set; }
    [JsonPropertyName("transparentIconPath")]
    public string? TransparentIconPath { get; set; }
    [JsonPropertyName("color")]
    public Color? Color { get; set; }
}

public record Color
{
    [JsonPropertyName("red")]
    public int Red { get; set; }
    [JsonPropertyName("green")]
    public int Green { get; set; }
    [JsonPropertyName("blue")]
    public int Blue { get; set; }
    [JsonPropertyName("alpha")]
    public int Alpha { get; set; }
}