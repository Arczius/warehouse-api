namespace CargoHub.Dtos.Transfers;

public record TransferDTO
{
    public int Id { get; init; }
    public int FromLocationId { get; init; }
    public int ToLocationId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public string TransferStatus { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record CreateTransferDTO
{
    public int FromLocationId { get; init; }
    public int ToLocationId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public string TransferStatus { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record UpdateTransferDTO
{
    public int FromLocationId { get; init; }
    public int ToLocationId { get; init; }
    public string Reference { get; init; } = string.Empty;
    public string TransferStatus { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
