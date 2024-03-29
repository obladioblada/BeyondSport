using beyondsports.models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
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
        // Arrange

        // Act
        var response = await _client.GetAsync("/Player/1");
       
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseContent);
        var user = JsonConvert.DeserializeObject<Player>(responseContent);
        Assert.NotNull(user);
        Assert.Equal(1, user.id);
        Assert.Equal("Diego Armando Maradona", user.name);
        Assert.Equal(32, user.age);
        Assert.Equal(1, user.team_id);
    }

    [Fact]
    public async Task Get_TeamPlayers()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/team/1/players");
       
        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseContent);
        var user = JsonConvert.DeserializeObject<Player[]>(responseContent);
        Assert.NotNull(user);
        Assert.Single(user);
    }

    [Fact]
    public async Task Post_AddNewPlayer()
    {
        // Arrange
        var newPlayer = new Player {
            id = 3,
            name = "Marco Van Basten",
            age = 22,
            team_id = 1
        };
       

        // Act
        var response = await _client.PostAsJsonAsync("/Player", newPlayer);
    

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseContent = await response.Content.ReadAsStringAsync();
        var player = JsonConvert.DeserializeObject<Player>(responseContent);
        Assert.NotNull(player);
        Assert.Equal(newPlayer.id, player.id);
        Assert.Equal(newPlayer.name, player.name);
        Assert.Equal(newPlayer.age, player.age);
        Assert.Equal(newPlayer.team_id, player.team_id);
    }
    
}
