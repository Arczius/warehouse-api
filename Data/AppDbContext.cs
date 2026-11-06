namespace Warehouse.Data;

using Models.Auth;
using Models.Orders;
using Models.Warehouses;
using Models.Products;
using Models.Suppliers;
using Models.Transfers;
using Models.Shipments;

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
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Transfer> Transfers => Set<Transfer>();
    public DbSet<TransferItem> TransferItems => Set<TransferItem>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<ShipmentItem> ShipmentItems => Set<ShipmentItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiEnd>()
            .HasIndex(e => e.Name)
            .IsUnique(true);
    }

}
