namespace Warehouse.Data;

using Models.Auth;
using Models.Orders;
using Models.Warehouses;
using Models.Products;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<ApiEnd> Endpoints => Set<ApiEnd>();
    public DbSet<Acces> Acces => Set<Acces>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<ItemGroup> ItemGroups => Set<ItemGroup>();
    public DbSet<ItemLine> ItemLines => Set<ItemLine>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiEnd>()
            .HasIndex(e => e.Name)
            .IsUnique(true);
    }

}
