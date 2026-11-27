using CargoHub.Dtos.Products;
using CargoHub.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/ItemTypes")]
public class ItemTypeController : ControllerBase
{
    private readonly IItemTypeService _itemType;

    public ItemTypeController(IItemTypeService itemType)
    {
        _itemType = itemType;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemTypeDTO>>> GetAll() =>
        Ok(await _itemType.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemTypeDTO>> GetById(int id)
    {
        var itemType = await _itemType.GetByIdAsync(id);
        return itemType is null ? NotFound() : Ok(itemType);
    }

    [HttpPost]
    public async Task<ActionResult<ItemTypeDTO>> Create(CreateItemTypeDTO dto)
    {
        var created = await _itemType.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateItemTypeDTO dto) =>
        await _itemType.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _itemType.DeleteAsync(id) ? NoContent() : NotFound();
}
