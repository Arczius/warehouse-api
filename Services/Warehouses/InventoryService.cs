namespace CargoHub.Services.Warehouses;

using Data;
using Dtos.Warehouses;
using Models.Warehouses;

// Inventory heeft een samengestelde key (ItemId + LocationId) en implementeert geen IEntity,
// daarom wordt hier direct de AppDbContext gebruikt in plaats van IRepository<T>.
public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryDTO>> GetAllAsync()
    {
        var inventories = await _context.Inventories.ToListAsync();
        return inventories.Select(ToDto).ToList();
    }

    public async Task<InventoryDTO?> GetByIdAsync(int itemId, int locationId)
    {
        var inventory = await FindAsync(itemId, locationId);
        return inventory is null ? null : ToDto(inventory);
    }

    public async Task<InventoryDTO> CreateAsync(CreateInventoryDTO dto)
    {
        var inventory = new Inventory
        {
            ItemId = dto.ItemId,
            LocationId = dto.LocationId,
            QuantityOnHand = dto.QuantityOnHand,
            QuantityExpected = dto.QuantityExpected,
            QuantityOrdered = dto.QuantityOrdered,
            QuantityAllocated = dto.QuantityAllocated,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();

        return ToDto(inventory);
    }

    public async Task<bool> DeleteAsync(int itemId, int locationId)
    {
        var inventory = await FindAsync(itemId, locationId);
        if (inventory is null) return false;

        _context.Inventories.Remove(inventory);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<InventoryDTO?> UpdateAsync(int itemId, int locationId, UpdateInventoryDTO dto)
    {
        var inventory = await FindAsync(itemId, locationId);
        if (inventory is null) return null;

        inventory.QuantityOnHand = dto.QuantityOnHand;
        inventory.QuantityExpected = dto.QuantityExpected;
        inventory.QuantityOrdered = dto.QuantityOrdered;
        inventory.QuantityAllocated = dto.QuantityAllocated;
        inventory.CreatedAt = dto.CreatedAt;
        inventory.UpdatedAt = dto.UpdatedAt;

        await _context.SaveChangesAsync();
        return ToDto(inventory);
    }

    private Task<Inventory?> FindAsync(int itemId, int locationId) =>
        _context.Inventories.FirstOrDefaultAsync(i => i.ItemId == itemId && i.LocationId == locationId);

    private static InventoryDTO ToDto(Inventory inventory) => new()
    {
        ItemId = inventory.ItemId,
        LocationId = inventory.LocationId,
        QuantityOnHand = inventory.QuantityOnHand,
        QuantityExpected = inventory.QuantityExpected,
        QuantityOrdered = inventory.QuantityOrdered,
        QuantityAllocated = inventory.QuantityAllocated,
        CreatedAt = inventory.CreatedAt,
        UpdatedAt = inventory.UpdatedAt,
    };
}
