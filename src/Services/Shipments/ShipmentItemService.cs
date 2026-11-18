namespace CargoHub.Services.Shipments;

using Dtos.Shipments;
using Models.Shipments;
using Repositories;

public class ShipmentItemService : IShipmentItemService
{
    private readonly IRepository<ShipmentItem> _shipmentItems;

    public ShipmentItemService(IRepository<ShipmentItem> shipmentItems)
    {
        _shipmentItems = shipmentItems;
    }

    public async Task<List<ShipmentItemDTO>> GetAllAsync()
    {
        var shipmentItems = await _shipmentItems.GetAllAsync();
        return shipmentItems.Select(ToDto).ToList();
    }

    public async Task<ShipmentItemDTO?> GetByIdAsync(int id)
    {
        var shipmentItem = await _shipmentItems.GetByIdAsync(id);
        return shipmentItem is null ? null : ToDto(shipmentItem);
    }

    public async Task<ShipmentItemDTO> CreateAsync(CreateShipmentItemDTO dto)
    {
        var shipmentItem = new ShipmentItem
        {
            ShipmentId = dto.ShipmentId,
            ItemId = dto.ItemId,
            Amount = dto.Amount,
        };

        _shipmentItems.Add(shipmentItem);
        await _shipmentItems.SaveChangesAsync();

        return ToDto(shipmentItem);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var shipmentItem = await _shipmentItems.GetByIdAsync(id);
        if (shipmentItem is null) return false;

        _shipmentItems.Delete(shipmentItem);
        await _shipmentItems.SaveChangesAsync();

        return true;
    }

    public async Task<ShipmentItemDTO?> UpdateAsync(int id, UpdateShipmentItemDTO dto)
    {
        var shipmentItem = await _shipmentItems.GetByIdAsync(id);
        if (shipmentItem is null) return null;

        shipmentItem.ShipmentId = dto.ShipmentId;
        shipmentItem.ItemId = dto.ItemId;
        shipmentItem.Amount = dto.Amount;

        await _shipmentItems.SaveChangesAsync();
        return ToDto(shipmentItem);
    }

    private static ShipmentItemDTO ToDto(ShipmentItem shipmentItem) => new()
    {
        Id = shipmentItem.Id,
        ShipmentId = shipmentItem.ShipmentId,
        ItemId = shipmentItem.ItemId,
        Amount = shipmentItem.Amount,
    };
}
