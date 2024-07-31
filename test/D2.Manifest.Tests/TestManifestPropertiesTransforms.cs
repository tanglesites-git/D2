using D2.Manifest.Domain;
using System.Text.Json;

namespace D2.Manifest.Tests;

public class TestManifestPropertiesTransforms
{
    private readonly ManifestRoot _json;
    private const string filename = @"A:\Projects\D2\test\D2.Manifest.Tests\manifest.json";

    public TestManifestPropertiesTransforms()
    {
        using (var stream = File.OpenRead(filename))
        {
            _json = JsonSerializer.DeserializeAsync(stream, ManifestRootContext.Default.ManifestRoot).Result!;
        }

    }

    [Fact]
    public void TestManifestRootIsNotNull()
    {
        Assert.NotNull(_json);
    }
    
    [Fact]
    public void TestManifestResponseIsNotNull()
    {
        Assert.NotNull(_json.Response);
    }
    
    [Fact]
    public void TestManifestRootHasVersion()
    {
        Assert.Equal("226893.24.07.17.1731-2-bnet.56363", _json.Response.Version);
    }
}