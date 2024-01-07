using beyondsports.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace beyondsports.controllers {

/// <summary>
/// Team API
/// </summary>
[ApiController]
[Route("[controller]")]
public class TeamController(ILogger<TeamController> logger) : ControllerBase
{
    private readonly ILogger<TeamController> _logger = logger;

    /// <summary>
    /// Get a specific team.
    /// </summary>
    [HttpGet("{id}")]
    [Produces("application/json")]
    public IActionResult Get(string id)
    {
        // return specific item
        _logger.LogInformation("Returning " + id + "team");
        return Ok();
    }

     /// <summary>
    /// Get all players of a specific team.
    /// </summary>
    [HttpGet("{id}/players")]
    [Produces("application/json")]
    public IActionResult GetTeamPlayers(string id)
    {
        _logger.LogInformation("Deleting " + id + " team");
        return Ok();
        // delete an item
    }

    /// <summary>
    /// Save a new team.
    /// </summary>
    [HttpPost]
    [Consumes("application/json")]
    public IActionResult Post([FromBody] Team value)
    {
        // add new item
         _logger.LogInformation("Saving " + value.name + " team");
        return Ok();

    }

    /// <summary>
    /// Update a specific team.
    /// </summary>
    [HttpPut]
    [Consumes("application/json")]
    public IActionResult Put([FromBody] Team value)
    {
        // update an item
        _logger.LogInformation("Updating " + value.name + " team");
         return Ok();
    }

    /// <summary>
    /// Delete a specific team.
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _logger.LogInformation("Deleting " + id + " team");
         return Ok();
        // delete an item
    }
}

}


