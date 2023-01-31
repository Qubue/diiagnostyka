using Domain.Core;
using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

internal class ItemItemRepository : IItemRepository
{
    private readonly ApplicationContext _dbContext;

    public ItemItemRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _dbContext.Items
            .Include(i => i.Color)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items.Select(i => new Item
        {
            Color = i.Color.Color,
            Code = i.Code,
            Notes = i.Notes,
            Id = i.Id,
            Name = i.Name
        }).ToList();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var itemEntity = new ItemEntity { Id = id };
        _dbContext.Entry(itemEntity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}