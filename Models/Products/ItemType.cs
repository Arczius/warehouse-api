namespace CargoHub.Models.Products;

[Table("ItemType")]
public class ItemType : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
