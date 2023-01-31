using Domain.Core;
using Services.Models;

namespace Services;

internal class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public async Task<IReadOnlyCollection<ItemDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync(cancellationToken);
        return items.Select(i => new ItemDto(i.Id, i.Color, i.Name, i.Notes, i.Code)).ToList();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return _itemRepository.DeleteAsync(id, cancellationToken);
    }

    public Task UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken)
    {
        var item = new Item
        {
            Id = itemDto.Id,
            Color = itemDto.Color,
            Code = itemDto.Code,
            Name = itemDto.Name,
            Notes = itemDto.Notes,
        };
        
        return _itemRepository.UpdateAsync(item, cancellationToken);
    }
}