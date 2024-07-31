using System.Net;
using D2.Manifest.Infrastructure;
using Moq;
using Moq.Protected;

namespace D2.Manifest.Tests;

public class ManifestUnitTests
{
    private readonly Mock<IHttpClientFactory> _mockFactory = new();
    private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler = new();
    private readonly HttpClient client;

    public ManifestUnitTests()
    {
        client = new HttpClient(_mockHttpMessageHandler.Object);
        client.BaseAddress = new Uri("https://www.bungie.net");
    }


    [Fact]
    public async Task TestGetManifestAsync()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        var manifest = "Test Manifest";
        _mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(manifest)
            });

        // Act
        var result = await manifestHttpClient.GetManifestAsync();

        // Assert
        Assert.Equal(manifest, result);
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsHttpRequestException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<HttpRequestException>();

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(() => manifestHttpClient.GetManifestAsync());
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsInvalidOperationException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<InvalidOperationException>();

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(() => manifestHttpClient.GetManifestAsync());
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsTaskCanceledException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<TaskCanceledException>();

        // Act & Assert
        Assert.ThrowsAsync<TaskCanceledException>(() => manifestHttpClient.GetManifestAsync());
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsUriFormatException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<UriFormatException>();

        // Act & Assert
        Assert.ThrowsAsync<UriFormatException>(() => manifestHttpClient.GetManifestAsync());
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsArgumentNullException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<ArgumentNullException>();

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => manifestHttpClient.GetManifestAsync());
    }
    
    [Fact]
    public void TestGetManifestAsync_ThrowsArgumentException()
    {
        // Arrange
        _mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        var manifestHttpClient = new TestManifestHttpClient(_mockFactory.Object);
        SetupMock<ArgumentException>();

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => manifestHttpClient.GetManifestAsync());
    }

    private void SetupMock<T>() where T : Exception, new()
    {
        _mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new T());
    }
}