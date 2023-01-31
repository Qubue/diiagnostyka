namespace Domain.Entities;

public sealed class ColorEntity
{
    public int Id { get; set; }
    public string Color { get; set; }
    public ICollection<ItemEntity> Items { get; set; }
}