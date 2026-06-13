namespace Restaurant.Api.Entities;

public class Food
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

    public Category Category { get; set; }
    public long CategoryId { get; set; }
}
