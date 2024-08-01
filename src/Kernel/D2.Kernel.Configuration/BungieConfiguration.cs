namespace D2.Kernel.Configuration;

public class BungieConfiguration
{
    public const string SectionName = nameof(BungieConfiguration);
    public string ApiKey { get; set; } = string.Empty;
    public string BaseAddress { get; set; } = string.Empty;
}
