namespace Warehouse.Dtos.Shipments;

public record ShipmentItemDTO
{
    public int Id { get; init; }
    public int ShipmentId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}

public record CreateShipmentItemDTO
{
    public int ShipmentId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}

public record UpdateShipmentItemDTO
{
    public int ShipmentId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}
