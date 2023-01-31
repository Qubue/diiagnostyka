using Services.Models;

namespace Services;

public interface IItemService
{
    Task<IReadOnlyCollection<ItemDto>> GetAllAsync(CancellationToken cancellationToken);
}