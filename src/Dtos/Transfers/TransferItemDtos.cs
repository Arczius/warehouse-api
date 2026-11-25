namespace CargoHub.Dtos.Transfers;

public record TransferItemDTO
{
    public int Id { get; init; }
    public int TransferId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}

public record CreateTransferItemDTO
{
    public int TransferId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}

public record UpdateTransferItemDTO
{
    public int TransferId { get; init; }
    public int ItemId { get; init; }
    public int Amount { get; init; }
}
