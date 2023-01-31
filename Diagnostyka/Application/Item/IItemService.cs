using Services.Models;

namespace Application.Item;

public interface IItemService
{
    Task<IReadOnlyCollection<ItemDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task UpdateAsync(ItemDto item, CancellationToken cancellationToken);
}
