using D2.Manifest.Application;

namespace D2.Manifest.Infrastructure;

public class ManifestIOClient : IManifestIOClient
{
    private const string ManifestFileName = "manifest.json";
    public async Task WriteManifestAsync(string manifest)
    {
        if (Path.Exists(ManifestFileName))
        {
            return;
        }
        await File.WriteAllTextAsync(ManifestFileName, manifest);
    }
}