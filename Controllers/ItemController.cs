using CargoHub.Dtos.Products;
using CargoHub.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _item;

    public ItemController(IItemService item)
    {
        _item = item;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDTO>>> GetAll() =>
        Ok(await _item.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemDTO>> GetById(int id)
    {
        var item = await _item.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDTO>> Create(CreateItemDTO dto)
    {
        var created = await _item.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateItemDTO dto) =>
        await _item.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _item.DeleteAsync(id) ? NoContent() : NotFound();
}
