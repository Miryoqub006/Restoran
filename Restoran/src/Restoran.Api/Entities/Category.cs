namespace Restaurant.Api.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
