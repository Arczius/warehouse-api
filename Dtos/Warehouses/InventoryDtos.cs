namespace Warehouse.Dtos.Warehouses;

public record InventoryDTO
{
    public int ItemId { get; init; }
    public int LocationId { get; init; }
    public int QuantityOnHand { get; init; }
    public int QuantityExpected { get; init; }
    public int QuantityOrdered { get; init; }
    public int QuantityAllocated { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record CreateInventoryDTO
{
    public int ItemId { get; init; }
    public int LocationId { get; init; }
    public int QuantityOnHand { get; init; }
    public int QuantityExpected { get; init; }
    public int QuantityOrdered { get; init; }
    public int QuantityAllocated { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

// ItemId en LocationId vormen samen de primary key en kunnen daarom niet worden aangepast.
public record UpdateInventoryDTO
{
    public int QuantityOnHand { get; init; }
    public int QuantityExpected { get; init; }
    public int QuantityOrdered { get; init; }
    public int QuantityAllocated { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
