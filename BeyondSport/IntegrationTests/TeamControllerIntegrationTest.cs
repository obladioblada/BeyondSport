// SampleControllerIntegrationTest.cs
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class TeamControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TeamControllerIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ReturnPlayerByID()
    {
        // Act
        var response = await _client.GetAsync("/player/1");
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("Hello, World!", await response.Content.ReadAsStringAsync());
    }
}
