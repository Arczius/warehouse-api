namespace Warehouse.Dtos.Orders;

public record OrderDTO
{
    public int Id { get; init; }
    public int ClientId { get; init; }
    public int WarehouseId { get; init; }
    public int ShipToClientId { get; init; }
    public int BillToClientId { get; init; }
    public string OrderDate { get; init; } = string.Empty;
    public string RequestDate { get; init; } = string.Empty;
    public string Reference { get; init; } = string.Empty;
    public string OrderNumber { get; init; } = string.Empty;
    public string OrderStatus { get; init; } = string.Empty;
    public string ShippingNotes { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record CreateOrderDTO
{
    public int ClientId { get; init; }
    public int WarehouseId { get; init; }
    public int ShipToClientId { get; init; }
    public int BillToClientId { get; init; }
    public string OrderDate { get; init; } = string.Empty;
    public string RequestDate { get; init; } = string.Empty;
    public string Reference { get; init; } = string.Empty;
    public string OrderNumber { get; init; } = string.Empty;
    public string OrderStatus { get; init; } = string.Empty;
    public string ShippingNotes { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record UpdateOrderDTO
{
    public int ClientId { get; init; }
    public int WarehouseId { get; init; }
    public int ShipToClientId { get; init; }
    public int BillToClientId { get; init; }
    public string OrderDate { get; init; } = string.Empty;
    public string RequestDate { get; init; } = string.Empty;
    public string Reference { get; init; } = string.Empty;
    public string OrderNumber { get; init; } = string.Empty;
    public string OrderStatus { get; init; } = string.Empty;
    public string ShippingNotes { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}