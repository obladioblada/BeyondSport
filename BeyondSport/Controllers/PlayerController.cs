using beyondsports.dbContext;
using beyondsports.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace beyondsports.controllers {
/// <summary>
/// Player API
/// </summary>
[ApiController]
[Route("[controller]")]
public class PlayerController(ILogger<PlayerController> logger, ApplicationContext context) : ControllerBase
{
    private readonly ILogger<PlayerController> _logger = logger;
    private readonly ApplicationContext _dbContext  = context;

    /// <summary>
    /// Get a specific player.
    /// </summary>
    /// <param name="id">The player id</param>
    /// <returns>The player</returns>
    /// <response code="404">Player not found</response>        
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType<Player>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        _logger.LogInformation("Trying to find player with id : " + id);
         var player = _dbContext.Player.Find(id);
         return player == null ? NotFound("Player Not Found") : Ok(player);
    }

    /// <summary>
    /// Save a new player.
    /// </summary>
    /// <param name="player">The player object</param>
    /// <returns>The inserted player</returns>
    /// <response code="400">If the player object is not valid</response> 
    /// <response code="500">If an unexpected error occurred</response>   
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType<Player>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post([FromBody] Player player)
    {
        var playerFromDb =  _dbContext.Player.Find(player.id);
        if (playerFromDb == null) {
            return NotFound("Player not found");
        }

        try
        {
            _dbContext.Add(player);
            _dbContext.SaveChanges();
            return Ok(player);
        }
        catch (Exception e) {
            _logger.LogError(e, "Error occured while adding new player!");
            return StatusCode(500, "Internal Server Error");
        }
       
        
    }

    /// <summary>
    /// Update a specific player.
    /// </summary>
    /// <param name="player">The Player object</param>
    /// <returns>The inserted player</returns>
    /// <response code="400">If the player object is not valid</response> 
    /// <response code="500">If an unexpected error occurred</response>   
    [HttpPut]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType<Player>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Put([FromBody] Player player)
    {
        var playerFromDb =  _dbContext.Player.Find(player.id);
        if (playerFromDb == null) {
            return NotFound("Player not found");
        }
    
        try
        {
            _dbContext.Update(player);
            _dbContext.SaveChanges();
            return Ok(player);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occured while saving player!");
            return StatusCode(500, "Internal Server Error");
        }
       
    }

    /// <summary>
    /// Delete a specific player.
    /// </summary>
    /// <param name="id">The Player id</param>
    /// <returns>The deleted player</returns>
    /// <response code="404">Player not found</response>      
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting team with id {}", id);
        var playerFromDb =  _dbContext.Player.Find(id);
        if (playerFromDb == null) {
            return NotFound("Player not found");
        }
        _dbContext.Player.Remove(playerFromDb);
        _dbContext.SaveChanges();
        return Ok();
    }
}

}
