namespace warehouse_api.RouteGroups;

public static class WarehouseGroup
{
    public static RouteGroupBuilder MapWarehouseGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("warehouse");

        group.MapGet("/", () =>
        {
            return Results.Ok("Getting all warehouses!");
        })
        .WithName("GetWarehouses");

        return group;
    }
}

