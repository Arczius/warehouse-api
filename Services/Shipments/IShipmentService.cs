namespace CargoHub.Services.Shipments;

using Dtos.Shipments;

public interface IShipmentService
{
    Task<List<ShipmentDTO>> GetAllAsync();
    Task<ShipmentDTO?> GetByIdAsync(int id);
    Task<ShipmentDTO> CreateAsync(CreateShipmentDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ShipmentDTO?> UpdateAsync(int id, UpdateShipmentDTO dto);
}
