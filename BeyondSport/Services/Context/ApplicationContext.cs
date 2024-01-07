using beyondsports.models;
using Microsoft.EntityFrameworkCore;

namespace beyondsports.dbContext {
  
  public class ApplicationContext : DbContext {

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    public DbSet<Player> Player { get; set; }
    public DbSet<Team> Team { get; set; }

  }
}
