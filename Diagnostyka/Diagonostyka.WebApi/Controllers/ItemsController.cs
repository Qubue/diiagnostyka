using Application.Item;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace Diagonostyka.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet, Authorize]
    [ProducesResponseType(typeof(IEnumerable<ItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllItems(CancellationToken cancellationToken)
    {
        var result = await _itemService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrator")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItem(int id, CancellationToken cancellationToken)
    {
        var result = await _itemService.DeleteAsync(id, cancellationToken);
        return result ? Ok() : NotFound();
    }

    [HttpPatch("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "administrator")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateItem(int id, ItemDto item, CancellationToken cancellationToken)
    {
        await _itemService.UpdateAsync(item with { Id = id }, cancellationToken);
        return Ok();
    }
}
