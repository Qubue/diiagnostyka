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

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var itemEntity = new ItemEntity { Id = id };
            _dbContext.Entry(itemEntity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return false;
        }
    }

    public async Task UpdateAsync(Item item, CancellationToken cancellationToken)
    {
        var itemEntity = await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == item.Id, cancellationToken);
        if (itemEntity is null)
            throw new Exception();

        var color = await _dbContext.Colors.FirstAsync(c => c.Color == item.Color, cancellationToken);
        itemEntity = new ItemEntity
        {
            Code = item.Code,
            Name = item.Name,
            Notes = item.Notes,
            ColorId = color.Id,
            Id = color.Id,
        };

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}