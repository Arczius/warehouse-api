using CargoHub.Dtos.Orders;
using CargoHub.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Clients")]
public class ClientController : ControllerBase
{
    private readonly IClientService _client;

    public ClientController(IClientService client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientDTO>>> GetAll() =>
        Ok(await _client.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClientDTO>> GetById(int id)
    {
        var product = await _client.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDTO>> Create(CreateClientDTO dto)
    {
        var created = await _client.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateClientDTO dto) =>
        await _client.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _client.DeleteAsync(id) ? NoContent() : NotFound();

}
