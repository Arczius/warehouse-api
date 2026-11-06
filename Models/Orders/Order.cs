namespace Warehouse.Models.Orders;

using Models.Warehouses;

[Table("Order")]
public class Order : IEntity
{
    [Key]
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;

    public int ShipToClientId { get; set; }
    public Client ShipToClient { get; set; } = null!;

    public int BillToClientId { get; set; }
    public Client BillToClient { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime RequestDate { get; set; }

    [Required]
    public string Reference { get; set; } = null!;

    [Required]
    public string OrderNumber { get; set; } = null!;

    [Required]
    public string OrderStatus { get; set; } = null!;

    public string? ShippingNotes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
