using System.Text.Encodings.Web;
using D2.Manifest.Domain;
using System.Text.Json;

namespace D2.Manifest.Tests;

public class TestManifestPropertiesTransforms
{
    private readonly ManifestRoot? _json;
    private const string filename = @"A:\Projects\D2\test\D2.Manifest.Tests\manifest.json";

    private readonly List<string> _mobileWorldContentPaths =
    [
        "/common/destiny2_content/sqlite/en/world_sql_content_0e5d5f3048975000dbca5cc59d8f3f79.content",
        "/common/destiny2_content/sqlite/fr/world_sql_content_c0307b1cb742c28e770eaf0724ca9abb.content",
        "/common/destiny2_content/sqlite/es/world_sql_content_bb0f9ca3669042c27aa13e9aa550c94c.content",
        "/common/destiny2_content/sqlite/es-mx/world_sql_content_bd907b5cfb1326c11d542253c0f871da.content",
        "/common/destiny2_content/sqlite/de/world_sql_content_efeaec390fecb9beb7fd80e660424df1.content",
        "/common/destiny2_content/sqlite/it/world_sql_content_aa2e4b6adbb23efd4c51d1e9193f7bcc.content",
        "/common/destiny2_content/sqlite/ja/world_sql_content_248a40baefff82565283e7b0eae8a5dc.content",
        "/common/destiny2_content/sqlite/pt-br/world_sql_content_b700a2768c81832cfa43c3ea64e1f40b.content",
        "/common/destiny2_content/sqlite/ru/world_sql_content_9853f3a6e799ef57dfae28d838d868ce.content",
        "/common/destiny2_content/sqlite/pl/world_sql_content_55f77d1208364d2b445e7eda0bc4dff4.content",
        "/common/destiny2_content/sqlite/ko/world_sql_content_ba993e041a0d846a4c8231b2e7898fd3.content",
        "/common/destiny2_content/sqlite/zh-cht/world_sql_content_2c84c0949c4360e25b9d8a6b0629c05f.content",
        "/common/destiny2_content/sqlite/zh-chs/world_sql_content_d79649e38e513bb3fb5689a36a1081dc.content"
    ];

    public TestManifestPropertiesTransforms()
    {
        var jsonString = File.ReadAllText(filename);
        _json = JsonSerializer.Deserialize(jsonString, typeof(ManifestRoot), new JsonSerializerOptions
        {
            TypeInfoResolver = ManifestRootContext.Default,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IncludeFields = true
        }) as ManifestRoot;
    }

    [Fact]
    public void TestManifestRootHasVersion()
    {
        Assert.Equal("226893.24.07.17.1731-2-bnet.56363", _json?.Response.Version);
    }

    [Fact]
    public void TestManifestRootIsNotNull()
    {
        Assert.NotNull(_json);
    }

    [Fact]
    public void TestManifestResponseIsNotNull()
    {
        Assert.NotNull(_json?.Response);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsIsNotNull()
    {
        Assert.NotNull(_json?.Response.MobileWorldContentPaths);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasEn()
    {
        Assert.Equal(_mobileWorldContentPaths[0], _json?.Response.MobileWorldContentPaths.En);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasFr()
    {
        Assert.Equal(_mobileWorldContentPaths[1], _json?.Response.MobileWorldContentPaths.Fr);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasEs()
    {
        Assert.Equal(_mobileWorldContentPaths[2], _json?.Response.MobileWorldContentPaths.Es);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasEsMx()
    {
        Assert.Equal(_mobileWorldContentPaths[3], _json?.Response.MobileWorldContentPaths.EsMx);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasDe()
    {
        Assert.Equal(_mobileWorldContentPaths[4], _json?.Response.MobileWorldContentPaths.De);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasIt()
    {
        Assert.Equal(_mobileWorldContentPaths[5], _json?.Response.MobileWorldContentPaths.It);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasJa()
    {
        Assert.Equal(_mobileWorldContentPaths[6], _json?.Response.MobileWorldContentPaths.Ja);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasPtBr()
    {
        Assert.Equal(_mobileWorldContentPaths[7], _json?.Response.MobileWorldContentPaths.PtBr);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasRu()
    {
        Assert.Equal(_mobileWorldContentPaths[8], _json?.Response.MobileWorldContentPaths.Ru);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasPl()
    {
        Assert.Equal(_mobileWorldContentPaths[9], _json?.Response.MobileWorldContentPaths.Pl);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasKo()
    {
        Assert.Equal(_mobileWorldContentPaths[10], _json?.Response.MobileWorldContentPaths.Ko);
    }


    [Fact]
    public void TestManifestMobileWorldContentPathsHasZhCht()
    {
        Assert.Equal(_mobileWorldContentPaths[11], _json?.Response.MobileWorldContentPaths.ZhCht);
    }

    [Fact]
    public void TestManifestMobileWorldContentPathsHasZhChs()
    {
        Assert.Equal(_mobileWorldContentPaths[12], _json?.Response.MobileWorldContentPaths.ZhChs);
    }
    
    [Fact]
    public void TestManifestJsonWorldComponentContentPathsIsNotNull()
    {
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths);
    }
    
    [Fact]
    public void TestManifestJsonWorldComponentContentPathsLocalizationIsNotNull()
    {
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.En);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Fr);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Es);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.EsMx);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.De);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.It);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Ja);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.PtBr);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Ru);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Pl);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.Ko);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.ZhCht);
        Assert.NotNull(_json?.Response.JsonWorldComponentContentPaths.ZhChs);
    }
    
    [Fact]
    public void TestManifestJsonWorldComponentContentPathsAreNotAnEmptyString()
    {
        Assert.False(string.IsNullOrEmpty(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyNodeStepSummaryDefinition));
        Assert.False(string.IsNullOrEmpty(_json?.Response.JsonWorldComponentContentPaths.En?.DestinyInventoryItemDefinition));
    }
}