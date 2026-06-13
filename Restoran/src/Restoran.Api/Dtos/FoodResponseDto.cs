namespace RestaurantAPI.Dtos
{
    public class FoodResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }

        // Ixtiyoriy: Klientga qulay bo'lishi uchun kategoriya nomini ham qo'shib yuboramiz
        public string CategoryName { get; set; } = string.Empty;
    }
}