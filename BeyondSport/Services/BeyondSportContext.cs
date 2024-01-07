using beyondsports.models;
using Microsoft.EntityFrameworkCore;


namespace beyondsports.dbContext {
  
  public class BeyondSportContext : DbContext {

  public BeyondSportContext(DbContextOptions<BeyondSportContext> options) : base(options) {
    
  }

  public DbSet<Player> Player { get; set; }
  public DbSet<Team> Team { get; set; }

  }
}
