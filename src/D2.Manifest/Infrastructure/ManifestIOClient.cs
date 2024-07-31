using D2.Manifest.Application;
using Microsoft.Extensions.Logging;

namespace D2.Manifest.Infrastructure;

public class ManifestIOClient : IManifestIOClient
{
    private const string ManifestFileName = "manifest.json";
    private readonly ILogger<ManifestIOClient> _logger;

    public ManifestIOClient(ILogger<ManifestIOClient> logger)
    {
        _logger = logger;
    }

    public async Task WriteManifestAsync(string manifest)
    {
        if (Path.Exists(ManifestFileName))
        {
            _logger.LogInformation("Manifest file already exists. Skipping write");
            return;
        }
        await File.WriteAllTextAsync(ManifestFileName, manifest);
    }
}