<<<<<<< HEAD
﻿namespace Warehouse.Auth;

[Table("Acces")]
public class Acces
{

=======
﻿namespace Warehouse.Models.Auth;

[Table("Acces")]
[PrimaryKey(nameof(UserId), nameof(ApiEndId))]
public class Acces
{
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    public int ApiEndId { get; set; }
    public ApiEnd ApiEnd { get; set; } = null!;

    public bool CanGet { get; set; }

    public bool CanPost { get; set; }

    public bool CanPut { get; set; }

    public bool CanDelete { get; set; }
>>>>>>> origin/Development
}
