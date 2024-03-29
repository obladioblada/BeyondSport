using beyondsports.dbContext;
using beyondsports.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace beyondsports.controllers {

/// <summary>
/// Team API
/// </summary>
[ApiController]
[Route("[controller]")]
public class TeamController(ILogger<TeamController> logger, ApplicationContext context) : ControllerBase
{
    private readonly ILogger<TeamController> _logger = logger;
    private readonly ApplicationContext _dbContext  = context;


    /// <summary>
    /// Get a specific team.
    /// </summary>
    /// <param name="id">The Team id</param>
    /// <returns>The team</returns>
    /// <response code="404">"Team not Found</response>  
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
    
        _logger.LogInformation("Trying to find team with id : {} ", id);
         var team = _dbContext.Team.Find(id);
         return team == null ? NotFound("Team not Found") : Ok(team);
    }

    /// <summary>
    /// Get all players of a specific team.
    /// </summary>
    /// <param name="id">The team id</param>
    /// <returns>The team</returns>
    /// <response code="404">Team not Found</response> 
    [HttpGet("{id}/players")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTeamPlayers(int id)
    {
        _logger.LogInformation("Getting players for team: {}",  id );
        var team = _dbContext.Team.Find(id);
        if (team == null) {
            return NotFound("Team not found");
        }
        return Ok(_dbContext.Player.Where(player => player.team_id == team.id).ToList());
        // delete an item
    }


    /// <summary>
    /// Save a new team.
    /// </summary>
    /// <param name="team">The Team object</param>
    /// <returns>The inserted team</returns>
    /// <response code="400">Team object is not valid or Team already exists</response> 
    /// <response code="404">Team not found</response>  
    /// <response code="500">If an unexpected error occurred</response> 
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType<Team>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post([FromBody] Team team)
    {

            var teamFromDb =  _dbContext.Team.Find(team.id);
            if (teamFromDb == null) {
                return BadRequest("A Team with this id already exists");
            }

            try
            {
                var entity = _dbContext.Add(team);
                _dbContext.SaveChanges();
                return Ok(entity.Entity);
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Error occured while adding new team!");
                return BadRequest(e.Message);
            }
            catch (Exception e)
        {
            _logger.LogError(e, "Error occured while adding new team!");
            return StatusCode(500, "Internal Server Error");
        }


    }

    /// <summary>
    /// Update a specific team.
    /// </summary>
    /// <param name="team">The Team object</param>
    /// <returns>The inserted team</returns>
    /// <response code="400">Team object is not valid</response> 
    /// <response code="500">If an unexpected error occurred</response> 
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType<Team>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public IActionResult Put([FromBody] Team team)
    {
        var teamFromDb = _dbContext.Team.AsNoTracking()
                  .Where(t => t.id.Equals(team.id))
                  .FirstOrDefault();
        
        if (teamFromDb == null) {
            return NotFound("Team not found");
        }

        
         try
        {
            var entity = _dbContext.Update(team);
            _dbContext.SaveChanges();
            return Ok(entity.Entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occured while saving Team!");
            return StatusCode(500, "Internal Server Error");
        }
    }

    /// <summary>
    /// Delete a specific team.
    /// </summary>
    /// <param name="id">The Team id</param>
    /// <returns>The deleted team</returns>
    /// <response code="404">Team not found</response>    
    /// <response code="500">Team cannot be deleted</response>    

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting team with id {}", id);

        var teamFromDb = _dbContext.Team.AsNoTracking()
                  .Where(t => t.id.Equals(id))
                  .FirstOrDefault();

        if (teamFromDb == null) {
            return NotFound("Team not found");
        }

        try {
            _dbContext.Team.Remove(teamFromDb);
            _dbContext.SaveChanges();
            return Ok(teamFromDb);
        } catch(Exception e) {
             _logger.LogError(e, "Error occured while deleting the Team: {}", id);
            return StatusCode(500, "Team cannot be deleted");
        }
    }
}

}
