namespace Warehouse.Dtos.Orders;

public record OrderItemDTO
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
    public float UnitPrice { get; init; }
}

public record CreateOrderItemDTO
{
    public int OrderId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
    public float UnitPrice { get; init; }
}

public record UpdateOrderItemDTO
{
    public int OrderId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
    public float UnitPrice { get; init; }
}