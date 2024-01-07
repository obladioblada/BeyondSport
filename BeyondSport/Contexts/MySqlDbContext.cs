using beyondsports.models;
using Microsoft.EntityFrameworkCore;

namespace beyondsports.dbContext {
  
  public sealed class MySqlDbContext : ApplicationContext {

  public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) {}}


}