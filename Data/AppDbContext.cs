using Warehouse.Auth;

namespace Warehouse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ApiEnd> Endpoints => Set<ApiEnd>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiEnd>()
            .HasIndex(e => e.Name)
            .IsUnique(true);
    }

}
