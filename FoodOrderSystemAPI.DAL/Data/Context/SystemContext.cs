using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI;

public class SystemContext : DbContext
{
    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}
