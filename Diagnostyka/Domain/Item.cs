namespace Domain.Core;

internal class Item 
{
    public int Id { get; set; }
    public string Color { get; init; }
    public string Name { get; init; }
    public string Notes { get; init; }
    public string Code { get; set; }
}
