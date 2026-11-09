using Warehouse.Repositories;
using Warehouse.Models.Orders;

namespace Warehouse.RouteGroups;

public static class ClientGroup
{
    public static RouteGroupBuilder MapClientGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/clients");

        group.MapGetAll<Client>("/");
        group.MapGetById<Client>("/{id}");
        group.MapGetSubResource<Client, Order>("/{id}/orders", id => order => order.ClientId == id || order.ShipToClientId == id || order.BillToClientId == id);
        group.Post<Client>("/", "clients");
        group.Delete<Client>("/{id}");

        group.MapPut("/{id:int}", async (int id, Client client, IRepository<Client> repo) =>
        {
            var existingClient = await repo.GetByIdAsync(id);
            if (existingClient is null) return Results.NotFound();

            existingClient.Name = client.Name;
            existingClient.Address = client.Address;
            existingClient.City = client.City;
            existingClient.ZipCode = client.ZipCode;
            existingClient.Province = client.Province;
            existingClient.Country = client.Country;
            existingClient.ContactName = client.ContactName;
            existingClient.ContactPhone = client.ContactPhone;
            existingClient.ContactEmail = client.ContactEmail;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

