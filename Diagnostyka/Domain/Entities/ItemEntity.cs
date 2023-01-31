namespace Domain.Core.Entities;

internal class ItemEntity
{
    public long Id { get; set; }
    public string Name { get; init; }
    public string Notes { get; init; }
    public string Code { get; set; }
    public int ColorId { get; set; }
    public virtual ColorEntity Color { get; set; }
}