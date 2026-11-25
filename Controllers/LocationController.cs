using CargoHub.Dtos.Warehouses;
using CargoHub.Services.Warehouses;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Locations")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _location;

    public LocationController(ILocationService location)
    {
        _location = location;
    }

    [HttpGet]
    public async Task<ActionResult<List<LocationDTO>>> GetAll() =>
        Ok(await _location.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LocationDTO>> GetById(int id)
    {
        var location = await _location.GetByIdAsync(id);
        return location is null ? NotFound() : Ok(location);
    }

    [HttpPost]
    public async Task<ActionResult<LocationDTO>> Create(CreateLocationDTO dto)
    {
        var created = await _location.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateLocationDTO dto) =>
        await _location.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _location.DeleteAsync(id) ? NoContent() : NotFound();
}
