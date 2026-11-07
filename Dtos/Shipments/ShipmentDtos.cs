namespace CargoHub.Dtos.Shipments;

public record ShipmentDTO
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public DateTime ShipmentDate { get; init; }
    public string ShipmentType { get; init; } = string.Empty;
    public string ShipmentStatus { get; init; } = string.Empty;
    public string CarrierName { get; init; } = string.Empty;
    public string ShipmentMethod { get; init; } = string.Empty;
    public string PaymentType { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record CreateShipmentDTO
{
    public int OrderId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public DateTime ShipmentDate { get; init; }
    public string ShipmentType { get; init; } = string.Empty;
    public string ShipmentStatus { get; init; } = string.Empty;
    public string CarrierName { get; init; } = string.Empty;
    public string ShipmentMethod { get; init; } = string.Empty;
    public string PaymentType { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record UpdateShipmentDTO
{
    public int OrderId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public DateTime ShipmentDate { get; init; }
    public string ShipmentType { get; init; } = string.Empty;
    public string ShipmentStatus { get; init; } = string.Empty;
    public string CarrierName { get; init; } = string.Empty;
    public string ShipmentMethod { get; init; } = string.Empty;
    public string PaymentType { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
