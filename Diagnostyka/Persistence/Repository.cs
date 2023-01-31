using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

internal class Repository<T> : IRepository<T> where T : Item, new()
{
    private readonly ApplicationContext _dbContext;

    public Repository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _dbContext.Items
            .Include(i => i.Color)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items.Select(i => new T
        {
            Color = i.Color.Color,
            Code = i.Code,
            Notes = i.Notes,
            Id = i.Id,
            Name = i.Name
        }).ToList();
    }
}