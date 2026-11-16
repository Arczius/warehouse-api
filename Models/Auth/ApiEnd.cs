namespace CargoHub.Models.Auth;

[Table("ApiEnd")]
public class ApiEnd
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
