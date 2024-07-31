using D2.Manifest.Application;

namespace D2.Manifest.Infrastructure;

public class ManifestApp : IManifestApp
{
    private readonly IManifestHttpClient _httpClient;
    private readonly IManifestIOClient _ioClient;

    public ManifestApp(IManifestHttpClient httpClient, IManifestIOClient ioClient)
    {
        _httpClient = httpClient;
        _ioClient = ioClient;
    }

    public async Task RunApp()
    {
        var manifestString = await _httpClient.GetManifestAsync();
        await _ioClient.WriteManifestAsync(manifestString);
    }
}

