namespace CargoHub.Services.Warehouses;

using Dtos.Warehouses;

public interface IWarehouseService
{
    Task<List<WarehouseDTO>> GetAllAsync();
    Task<WarehouseDTO?> GetByIdAsync(int id);
    Task<WarehouseDTO> CreateAsync(CreateWarehouseDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<WarehouseDTO?> UpdateAsync(int id, UpdateWarehouseDTO dto);
}
