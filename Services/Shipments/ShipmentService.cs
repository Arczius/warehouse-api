namespace Warehouse.Services.Shipments;

using Dtos.Shipments;
using Models.Shipments;
using Repositories;

public class ShipmentService : IShipmentService
{
    private readonly IRepository<Shipment> _shipments;

    public ShipmentService(IRepository<Shipment> shipments)
    {
        _shipments = shipments;
    }

    public async Task<List<ShipmentDTO>> GetAllAsync()
    {
        var shipments = await _shipments.GetAllAsync();
        return shipments.Select(ToDto).ToList();
    }

    public async Task<ShipmentDTO?> GetByIdAsync(int id)
    {
        var shipment = await _shipments.GetByIdAsync(id);
        return shipment is null ? null : ToDto(shipment);
    }

    public async Task<ShipmentDTO> CreateAsync(CreateShipmentDTO dto)
    {
        var shipment = new Shipment
        {
            OrderId = dto.OrderId,
            Reference = dto.Reference,
            ShipmentDate = dto.ShipmentDate,
            ShipmentType = dto.ShipmentType,
            ShipmentStatus = dto.ShipmentStatus,
            CarrierName = dto.CarrierName,
            ShipmentMethod = dto.ShipmentMethod,
            PaymentType = dto.PaymentType,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _shipments.Add(shipment);
        await _shipments.SaveChangesAsync();

        return ToDto(shipment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var shipment = await _shipments.GetByIdAsync(id);
        if (shipment is null) return false;

        _shipments.Delete(shipment);
        await _shipments.SaveChangesAsync();

        return true;
    }

    public async Task<ShipmentDTO?> UpdateAsync(int id, UpdateShipmentDTO dto)
    {
        var shipment = await _shipments.GetByIdAsync(id);
        if (shipment is null) return null;

        shipment.OrderId = dto.OrderId;
        shipment.Reference = dto.Reference;
        shipment.ShipmentDate = dto.ShipmentDate;
        shipment.ShipmentType = dto.ShipmentType;
        shipment.ShipmentStatus = dto.ShipmentStatus;
        shipment.CarrierName = dto.CarrierName;
        shipment.ShipmentMethod = dto.ShipmentMethod;
        shipment.PaymentType = dto.PaymentType;
        shipment.CreatedAt = dto.CreatedAt;
        shipment.UpdatedAt = dto.UpdatedAt;

        await _shipments.SaveChangesAsync();
        return ToDto(shipment);
    }

    private static ShipmentDTO ToDto(Shipment shipment) => new()
    {
        Id = shipment.Id,
        OrderId = shipment.OrderId,
        Reference = shipment.Reference,
        ShipmentDate = shipment.ShipmentDate,
        ShipmentType = shipment.ShipmentType,
        ShipmentStatus = shipment.ShipmentStatus,
        CarrierName = shipment.CarrierName,
        ShipmentMethod = shipment.ShipmentMethod,
        PaymentType = shipment.PaymentType,
        CreatedAt = shipment.CreatedAt,
        UpdatedAt = shipment.UpdatedAt,
    };
}
