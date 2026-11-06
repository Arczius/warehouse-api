namespace Warehouse.Models.Shipments;

using Models.Orders;

[Table("Shipment")]
public class Shipment : IEntity
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    [Required]
    public string Reference { get; set; } = null!;

    public DateTime ShipmentDate { get; set; }

    [Required]
    public string ShipmentType { get; set; } = null!;

    [Required]
    public string ShipmentStatus { get; set; } = null!;

    [Required]
    public string CarrierName { get; set; } = null!;

    [Required]
    public string ShippingMethod { get; set; } = null!;

    [Required]
    public string PaymentType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
