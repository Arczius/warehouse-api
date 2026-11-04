namespace Warehouse.Data;

using Models.Auth;
using Models.Orders;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ApiEnd> Endpoints => Set<ApiEnd>();
    public DbSet<Acces> Acces => Set<Acces>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiEnd>()
            .HasIndex(e => e.Name)
            .IsUnique(true);
    }

}
