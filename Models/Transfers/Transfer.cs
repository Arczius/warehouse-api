namespace Warehouse.Models.Transfers;

using Models.Warehouses;

[Table("Transfer")]
public class Transfer : IEntity
{
    [Key]
    public int Id { get; set; }

    public int FromLocationId { get; set; }
    public Location FromLocation { get; set; } = null!;

    public int ToLocationId { get; set; }
    public Location ToLocation { get; set; } = null!;

    [Required]
    public string Reference { get; set; } = null!;

    [Required]
    public string TransferStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
