namespace Persistence;

internal interface IRepository<T> where T : class
{
    Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken);
}