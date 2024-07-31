using D2.Manifest.Application;
using D2.Manifest.Infrastructure;

namespace D2.Manifest.Tests;

// Derived test TestManifestHttpClient class to override the DownloadAsync method




public class TestManifestHttpClient : ManifestHttpClient
{
    public TestManifestHttpClient(IHttpClientFactory factory) : base(factory)
    {
    }
}