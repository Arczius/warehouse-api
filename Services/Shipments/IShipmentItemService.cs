namespace Warehouse.Services.Shipments;

using Dtos.Shipments;

public interface IShipmentItemService
{
    Task<List<ShipmentItemDTO>> GetAllAsync();
    Task<ShipmentItemDTO?> GetByIdAsync(int id);
    Task<ShipmentItemDTO> CreateAsync(CreateShipmentItemDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ShipmentItemDTO?> UpdateAsync(int id, UpdateShipmentItemDTO dto);
}
