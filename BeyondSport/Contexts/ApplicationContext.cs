using beyondsports.models;
using Microsoft.EntityFrameworkCore;

namespace beyondsports.dbContext {
  
  public class ApplicationContext : DbContext {

    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions) {}

    protected ApplicationContext(DbContextOptions contextOptions): base(contextOptions) {}

    public DbSet<Player> Player { get; set; }
    public DbSet<Team> Team { get; set; }

  }
}
