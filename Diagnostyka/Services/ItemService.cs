using Domain.Core;
using Persistence;
using Services.Models;

namespace Services;

internal class ItemService : IItemService
{
    private readonly IRepository<Item> _repository;

    public ItemService(IRepository<Item> repository)
    {
        _repository = repository;
    }
    
    public async Task<IReadOnlyCollection<ItemDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync(cancellationToken);
        return items.Select(i => new ItemDto(i)).ToList();
    }
}