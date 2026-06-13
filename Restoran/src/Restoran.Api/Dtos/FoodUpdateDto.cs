namespace Restaurant.Api.Dtos
{
    public class FoodUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public long CategoryId { get; set; }
    }
}