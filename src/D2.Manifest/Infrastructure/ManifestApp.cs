using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using D2.Manifest.Application;
using D2.Manifest.Domain;

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
        // var _json = JsonSerializer.Deserialize<ManifestRoot>(manifestString);
        var _json = JsonSerializer.Deserialize(manifestString, typeof(ManifestRoot), new JsonSerializerOptions
        {
            TypeInfoResolver = ManifestRootContext.Default,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IncludeFields = true
            
        }) as ManifestRoot;
        var jsonString = JsonSerializer.Serialize(_json, typeof(ManifestRoot), new JsonSerializerOptions
        {
            TypeInfoResolver = ManifestRootContext.Default,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IncludeFields = true
        });
        Console.WriteLine(jsonString);
        Console.WriteLine(_json);
    }
}

