namespace CargoHub.Services.Warehouses;

using Dtos.Warehouses;

public interface IInventoryService
{
    Task<List<InventoryDTO>> GetAllAsync();
    Task<InventoryDTO?> GetByIdAsync(int itemId, int locationId);
    Task<InventoryDTO> CreateAsync(CreateInventoryDTO dto);
    Task<bool> DeleteAsync(int itemId, int locationId);
    Task<InventoryDTO?> UpdateAsync(int itemId, int locationId, UpdateInventoryDTO dto);
}
