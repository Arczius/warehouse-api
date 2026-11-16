namespace CargoHub.Models.Auth;

[Table("User")]
public class User
{
    [Key]
    public string ApiKey { get; set; } = null!;

    [Required]
    public string App { get; set; } = null!;
}
