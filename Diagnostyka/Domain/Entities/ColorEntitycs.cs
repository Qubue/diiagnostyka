namespace Domain.Core.Entities;

internal class ColorEntity
{
    public int Id { get; set; }
    public string Color { get; set; }
    public virtual ICollection<ItemEntity> Items { get; set; }
}