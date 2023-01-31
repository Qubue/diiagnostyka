namespace Application.Item;

public interface IItemRepository
{
    Task<IReadOnlyCollection<Domain.Item>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task UpdateAsync(Domain.Item item, CancellationToken cancellationToken);
}