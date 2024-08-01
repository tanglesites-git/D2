namespace D2.Manifest.Application;

public interface IManifestIOClient
{
    public Task WriteManifestAsync(string manifest);
    public Task WriteJsonDefinitionAsync(string json, string fileName);
}