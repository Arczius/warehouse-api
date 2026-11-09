using System.Linq.Expressions;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.RouteGroups;

public static class CrudRouteExtension
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

    public static RouteGroupBuilder MapGetSubResource<TMain, TSub>(
    this RouteGroupBuilder group,
    string route,
    Func<int, Expression<Func<TSub, bool>>> belongsToMain)
    where TMain : class, IEntity
    where TSub : class, IEntity
    {
        group.MapGet(route, async (int id, IRepository<TMain> mainRepo, IRepository<TSub> subRepo) =>
        {
            var existingEntity = await mainRepo.GetByIdAsync(id);
            if (existingEntity is null) return Results.NotFound();
            var resource = await subRepo.FindAsync(belongsToMain(id));
            return Results.Ok(resource);
        });

        return group;
    }


    public static RouteGroupBuilder Post<T>(this RouteGroupBuilder group, string route, string resource) where T : class, IEntity
    {
        group.MapPost(route, async (T entity, IRepository<T> repo) =>
        {
            repo.Add(entity);
            await repo.SaveChangesAsync();
            return Results.Created($"/api/v1/{resource}/{entity.Id}", entity);
        });

        return group;
    }

    public static RouteGroupBuilder Delete<T>(this RouteGroupBuilder group, string route) where T : class, IEntity
    {
        group.MapDelete(route, async (int id, IRepository<T> repo) =>
        {
            var existingEntity = await repo.GetByIdAsync(id);
            if (existingEntity is null) return Results.NotFound();
            repo.Delete(existingEntity);
            await repo.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}
