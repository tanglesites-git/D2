using System.Text.Json.Serialization;

namespace D2.Core.Domain.Entities;

public class ManifestRoot
{
    public ManifestResponse? Response { get; set; }
    public byte ErrorCode { get; set; }
    public byte ThrottleSeconds { get; set; }
    public string ErrorStatus { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public ManifestMessageData MessageData { get; set; } = new();
}


public class ManifestMessageData { }


[JsonSerializable(typeof(ManifestRoot))]
public partial class ManifestRootSerializableContext : JsonSerializerContext
{
}