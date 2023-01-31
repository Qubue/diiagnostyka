namespace Domain.Core;

internal interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllAsync(CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}