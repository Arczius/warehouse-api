using CargoHub.Dtos.Warehouses;
using CargoHub.Services.Warehouses;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Inventories")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventory;

    public InventoryController(IInventoryService inventory)
    {
        _inventory = inventory;
    }

    [HttpGet]
    public async Task<ActionResult<List<InventoryDTO>>> GetAll() =>
        Ok(await _inventory.GetAllAsync());

    [HttpGet("{itemId:int}/{locationId:int}")]
    public async Task<ActionResult<InventoryDTO>> GetById(int itemId, int locationId)
    {
        var inventory = await _inventory.GetByIdAsync(itemId, locationId);
        return inventory is null ? NotFound() : Ok(inventory);
    }

    [HttpPost]
    public async Task<ActionResult<InventoryDTO>> Create(CreateInventoryDTO dto)
    {
        var created = await _inventory.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { created.ItemId, created.LocationId }, created);
    }

    [HttpPut("{itemId:int}/{locationId:int}")]
    public async Task<IActionResult> Update(int itemId, int locationId, UpdateInventoryDTO dto) =>
        await _inventory.UpdateAsync(itemId, locationId, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{itemId:int}/{locationId:int}")]
    public async Task<IActionResult> Delete(int itemId, int locationId) =>
        await _inventory.DeleteAsync(itemId, locationId) ? NoContent() : NotFound();
}
