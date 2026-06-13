using Restaurant.Api.Dtos;
using Restaurant.Api.Entities;

namespace Restaurant.Api.Mappings
{
    public static class FoodMapping
    {
        // Food -> FoodResponseDto
        public static FoodResponseDto ToResponseDto(this Food food)
        {
            if (food == null) return null!;

            return new FoodResponseDto
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
                IsAvailable = food.IsAvailable,
                CategoryId = food.CategoryId,
                // Agar Category Navigation property Include qilingan bo'lsa, nomini olamiz
                CategoryName = food.Category != null ? food.Category.Name : string.Empty
            };
        }

        // FoodCreateDto -> Food
        public static Food ToEntity(this FoodCreateDto dto)
        {
            if (dto == null) return null!;

            return new Food
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable,
                CategoryId = dto.CategoryId
            };
        }

        // FoodUpdateDto -> Mavjud Food entitysini yangilash
        public static void UpdateEntity(this FoodUpdateDto dto, Food existingFood)
        {
            if (dto == null || existingFood == null) return;

            existingFood.Name = dto.Name;
            existingFood.Description = dto.Description;
            existingFood.Price = dto.Price;
            existingFood.IsAvailable = dto.IsAvailable;
            existingFood.CategoryId = dto.CategoryId;
        }
    }
}
