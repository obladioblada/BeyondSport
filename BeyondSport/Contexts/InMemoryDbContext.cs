using beyondsports.models;
using Microsoft.EntityFrameworkCore;

namespace beyondsports.dbContext {
  
    public sealed  class InMemoryDbContext : ApplicationContext {

    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseInMemoryDatabase("beyondSportsDB");
      
    }

    
  }
}