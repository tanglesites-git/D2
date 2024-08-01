using System.Text.Json.Serialization;

namespace D2.Manifest.Domain;

public class ManifestRoot
{
    public ManifestResponse Response { get; set; } = new();
    public byte ErrorCode { get; set; } = 1;
    public byte ThrottleSeconds { get; set; } = 0;
    public string ErrorStatus { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public ManifestMessageData MessageData { get; set; } = new();
}

public class ManifestMessageData
{
}

public class ManifestResponse
{
    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;
    [JsonPropertyName("mobileWorldContentPaths")]
    public ManifestMobileWorldContentPaths MobileWorldContentPaths { get; set; } = new();
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public ManifestJsonWorldComponentContentPaths JsonWorldComponentContentPaths { get; set; } = new();
}