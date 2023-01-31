using Domain.Core;

namespace Services.Models;

public class ItemDto
{
    public long Id { get; init; }
    public string Color { get; init; }
    public string Name { get; init; }
    public string Notes { get; init; }
    public string Code { get; set; }

    public ItemDto(Item item)
    {
        Color = item.Color;
        Name = item.Name;
        Notes = item.Notes;
        Code = item.Code;
        Id = item.Id;
    }
}