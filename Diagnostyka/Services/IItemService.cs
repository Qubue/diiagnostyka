using Services.Models;

namespace Services;

public interface IItemService
{
    Task<IReadOnlyCollection<ItemDto>> GetAllAsync(CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
