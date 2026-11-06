namespace Warehouse.Dtos.Orders;

public record ClientDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
    public string Province { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Contact { get; init; } = string.Empty;
    public string ContactPhone { get; init; } = string.Empty;
    public string ContactEmail { get; init; } = string.Empty;
    public string CreatedAt { get; init; } = string.Empty;
    public string UpdatedAt { get; init; } = string.Empty;
}

public record CreateClientDTO
{
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
    public string Province { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Contact { get; init; } = string.Empty;
    public string ContactPhone { get; init; } = string.Empty;
    public string ContactEmail { get; init; } = string.Empty;
    public string CreatedAt { get; init; } = string.Empty;
    public string UpdatedAt { get; init; } = string.Empty;
}

public record UpdateClientDTO
{
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
    public string Province { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Contact { get; init; } = string.Empty;
    public string ContactPhone { get; init; } = string.Empty;
    public string ContactEmail { get; init; } = string.Empty;
    public string CreatedAt { get; init; } = string.Empty;
    public string UpdatedAt { get; init; } = string.Empty;
}