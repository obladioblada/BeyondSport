using beyondsports.models;
using Microsoft.AspNetCore.Mvc;


namespace beyondsports.controllers {

/// <summary>
/// Team API
/// </summary>
[ApiController]
[Route("[controller]")]
public class TeamController(ILogger<PlayerController> logger) : ControllerBase
{
    private readonly ILogger<PlayerController> _logger = logger;

    /// <summary>
    /// Get a specific team.
    /// </summary>
    [HttpGet("{name}")]
    [Produces("application/json")]
    public Team Get(string name)
    {
        // return specific item
        _logger.LogInformation("Returning " + name + "team");
        return new Team(name);
    }

    /// <summary>
    /// Save a new team.
    /// </summary>
    [HttpPost]
    [Consumes("application/json")]
    public void Post([FromBody] Team value)
    {
        // add new item
         _logger.LogInformation("Saving " + value.Name + " team");

    }

    /// <summary>
    /// Update a specific team.
    /// </summary>
    [HttpPut]
    [Consumes("application/json")]
    public void Put([FromBody] Team value)
    {
        // update an item
        _logger.LogInformation("Updating " + value.Name + " team");
    }

    /// <summary>
    /// Delete a specific team.
    /// </summary>
    [HttpDelete("{name}")]
    public void Delete(string name)
    {
        _logger.LogInformation("Deleting " + name + " team");
        // delete an item
    }
}

}


