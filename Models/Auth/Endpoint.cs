namespace Warehouse.Auth;

[Table("Endpoint")]
public class ApiEnd
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
