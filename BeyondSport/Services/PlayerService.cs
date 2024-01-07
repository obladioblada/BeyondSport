using beyondsports.dbContext;
using beyondsports.models;
using Microsoft.EntityFrameworkCore;

public class PlayerService {
    private readonly BeyondSportContext _dbContext;
    private readonly Logger<PlayerService> _logger;

    public PlayerService(BeyondSportContext context, Logger<PlayerService>logger )
    {   _logger = logger;
        _dbContext = context;
    }

    public async Task<Player> GetPlayerByIdAsync(int id)
    {
        _logger.LogInformation("Trying to find player with id : " + id);
        return await _dbContext.Player.FindAsync(id);
    }

    public async Task AddPlayerAsync(Player product)
    {
        await _dbContext.Player.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePlayerAsync(Player player)
    {
        _dbContext.Entry(player).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePlayerAsync(int id)
    {
        var player = await _dbContext.Player.FindAsync(id);
        if (player ==null) {
        
        }
        _dbContext.Player.Remove(player);
        await _dbContext.SaveChangesAsync();
    }
}