using D2.Manifest.Application;
using Microsoft.Extensions.Logging;

namespace D2.Manifest.Infrastructure;

public class ManifestIOClient : IManifestIOClient
{
    private const string ManifestFileName = "manifest.json";
    private const string DataRootDirectory = @"A:\Projects\D2\Data";
    private readonly ILogger<ManifestIOClient> _logger;

    public ManifestIOClient(ILogger<ManifestIOClient> logger)
    {
        _logger = logger;
    }

    public async Task WriteManifestAsync(string manifest)
    {
        if (Path.Exists(Path.Combine(DataRootDirectory, ManifestFileName)))
        {
            _logger.LogInformation("Manifest file already exists. Skipping write");
            return;
        }
        await File.WriteAllTextAsync(Path.Combine(DataRootDirectory, ManifestFileName), manifest);
    }
    
    public async Task WriteJsonDefinitionAsync(string json, string fileName)
    {
        if (Path.Exists(fileName))
        {
            _logger.LogInformation("Json file already exists. Skipping write");
            return;
        }
        await File.WriteAllTextAsync(fileName, json);
    }
}