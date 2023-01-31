using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace Diagonostyka.WebApi.Controllers;

[ApiController]
[Route("[controller]/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllItems(CancellationToken cancellationToken)
    {
        var result = await _itemService.GetAllAsync(cancellationToken);
        return Ok(result);
    }
}