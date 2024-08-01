using System.Text.Encodings.Web;
using System.Text.Json;
using D2.Manifest.Application;
using D2.Manifest.Domain;

namespace D2.Manifest.Infrastructure;

public class ManifestApp : IManifestApp
{
    private readonly IManifestHttpClient _httpClient;
    private readonly IManifestIOClient _ioClient;
    private const string DataRootDirectory = @"A:\Projects\D2\Data";
    private const string InventoryItemDefinition = "DestinyInventoryItemDefinition.json";

    public ManifestApp(IManifestHttpClient httpClient, IManifestIOClient ioClient)
    {
        _httpClient = httpClient;
        _ioClient = ioClient;
    }

    public async Task RunApp()
    {
        var manifestString = await _httpClient.GetManifestAsync();
        await _ioClient.WriteManifestAsync(manifestString);
        var _json = JsonSerializer.Deserialize(manifestString, typeof(ManifestRoot), new JsonSerializerOptions
        {
            TypeInfoResolver = ManifestRootContext.Default,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IncludeFields = true
            
        }) as ManifestRoot;
        var urlList = new List<Task>
        {
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyInventoryItemDefinition!, "DestinyInventoryItemDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyStatDefinition!, "DestinyStatDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyCollectibleDefinition!, "DestinyCollectibleDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyDamageTypeDefinition!, "DestinyDamageTypeDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyLoreDefinition!, "DestinyLoreDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyEquipmentSlotDefinition!, "DestinyEquipmentSlotDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyPlugSetDefinition!, "DestinyPlugSetDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinySocketCategoryDefinition!, "DestinySocketCategoryDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyItemCategoryDefinition!, "DestinyItemCategoryDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinySeasonDefinition!, "DestinySeasonDefinition.json"),
            GetJsonResource(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyTraitDefinition!, "DestinyTraitDefinition.json"),
        };

        await Task.WhenAll(urlList);
    }

    private async Task GetJsonResource(string url, string filename)
    {
        var json = await _httpClient.GetJsonDefinitionAsync(url);
        await _ioClient.WriteJsonDefinitionAsync(json, Path.Combine(DataRootDirectory, filename));
    }
}

