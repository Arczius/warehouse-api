using CargoHub.Dtos.Warehouses;
using CargoHub.Services.Warehouses;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Warehouses")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouse;

    public WarehouseController(IWarehouseService warehouse)
    {
        _warehouse = warehouse;
    }

    [HttpGet]
    public async Task<ActionResult<List<WarehouseDTO>>> GetAll() =>
        Ok(await _warehouse.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WarehouseDTO>> GetById(int id)
    {
        var warehouse = await _warehouse.GetByIdAsync(id);
        return warehouse is null ? NotFound() : Ok(warehouse);
    }

    [HttpPost]
    public async Task<ActionResult<WarehouseDTO>> Create(CreateWarehouseDTO dto)
    {
        var created = await _warehouse.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateWarehouseDTO dto) =>
        await _warehouse.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _warehouse.DeleteAsync(id) ? NoContent() : NotFound();
}
