using D2.Manifest.Application;

namespace D2.Manifest.Infrastructure;

public class ManifestHttpClient : IManifestHttpClient
{
    private readonly IHttpClientFactory _factory;

    public ManifestHttpClient(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string> GetManifestAsync()
    {
        var client = _factory.CreateClient("ManifestClient");

        try
        {
            return await DownloadAsync(client);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (UriFormatException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<string> GetJsonDefinitionAsync(string url)
    {
        var client = _factory.CreateClient("ManifestClient");

        try
        {
            return await DownloadJsonDefinition(client, url);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (UriFormatException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async Task<string> DownloadAsync(HttpClient client)
    {
        return await client.GetStringAsync("/Platform/Destiny2/Manifest/");
    }

    private async Task<string> DownloadJsonDefinition(HttpClient client, string url)
    {
        return await client.GetStringAsync(url);
    }
}