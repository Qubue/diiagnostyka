namespace Domain.Core;

internal interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task UpdateAsync(Item item, CancellationToken cancellationToken);
}