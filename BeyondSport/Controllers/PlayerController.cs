using beyondsports.models;
using Microsoft.AspNetCore.Mvc;


namespace beyondsports.controllers {
/// <summary>
/// Player API
/// </summary>
[ApiController]
[Route("[controller]")]
public class PlayerController(ILogger<PlayerController> logger) : ControllerBase
{
    private readonly ILogger<PlayerController> _logger = logger;

    /// <summary>
    /// Get a specific player.
    /// </summary>
    [HttpGet("{id}")]
    [Produces("application/json")]
    public Player Get(int id)
    {
        // return specific item
        var player =  new Player(id, "totti", 40);
        return player;
    }

    /// <summary>
    /// Save a new player.
    /// </summary>
    [HttpPost]
    public void Post([FromBody] Player value)
    {
        // add new item

    }

    /// <summary>
    /// Update a specific player.
    /// </summary>
    [HttpPut("{id}")]
    [Consumes("application/json")]
    public void Put(int id, [FromBody] Player value)
    {
        // update an item
    }

    /// <summary>
    /// Delete a specific player.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        // delete an item
    }
}

}
