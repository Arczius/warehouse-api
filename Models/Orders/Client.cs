namespace Warehouse.Models.Orders;

[Table("Client")]
public class Client : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string ZipCode { get; set; } = null!;

    [Required]
    public string Province { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    public string ContactName { get; set; } = null!;

    [Required]
    public string ContactPhone { get; set; } = null!;

    [Required]
    public string ContactEmail { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
