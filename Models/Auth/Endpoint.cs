namespace CargoHub.Models.Auth;

[Table("Endpoint")]
public class Endpoint
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
