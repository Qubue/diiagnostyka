namespace Domain.Entities;

public sealed class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; init; }
    public string Notes { get; init; }
    public string Code { get; set; }
    public int ColorId { get; set; }
    public ColorEntity Color { get; set; }
}