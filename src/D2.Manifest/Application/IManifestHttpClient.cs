namespace D2.Manifest.Application;

public interface IManifestHttpClient
{
    public Task<string> GetManifestAsync();
}