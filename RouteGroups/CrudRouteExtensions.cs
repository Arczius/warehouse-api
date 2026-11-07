using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.RouteGroups;

public static class CrudRouteGroup
{
    public static RouteGroupBuilder MapGetAll<T>(this RouteGroupBuilder group, string route) where T : class, IEntity
    {
        group.MapGet(route, async (IRepository<T> repo) =>
        {
            var existingEntity = await repo.GetAllAsync();
            return Results.Ok(existingEntity);
        });

        return group;
    }

    public static RouteGroupBuilder MapGetById<T>(this RouteGroupBuilder group, string route) where T : class, IEntity
    {
        group.MapGet(route, async (int id, IRepository<T> repo) =>
        {
            var existingEntity = await repo.GetByIdAsync(id);
            return existingEntity is null
            ? Results.NotFound()
            : Results.Ok(existingEntity);
        });

        return group;
    }

}
