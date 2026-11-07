namespace Warehouse.Services.Warehouses;

using Dtos.Warehouses;

public interface ILocationService
{
    Task<List<LocationDTO>> GetAllAsync();
    Task<LocationDTO?> GetByIdAsync(int id);
    Task<LocationDTO> CreateAsync(CreateLocationDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<LocationDTO?> UpdateAsync(int id, UpdateLocationDTO dto);
}
