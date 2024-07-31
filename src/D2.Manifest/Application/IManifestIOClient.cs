namespace D2.Manifest.Application;

public interface IManifestIOClient
{
    public Task WriteManifestAsync(string manifest);
}