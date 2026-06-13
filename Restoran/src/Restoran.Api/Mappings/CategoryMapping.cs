using Restaurant.Api.Dtos;
using Restaurant.Api.Entities;

namespace Restaurant.Api.Mappings
{
    public static class CategoryMapping
    {
        // Category -> CategoryResponseDto
        public static CategoryResponseDto ToResponseDto(this Category category)
        {
            if (category == null) return null!;

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        // CategoryCreateDto -> Category
        public static Category ToEntity(this CategoryCreateDto dto)
        {
            if (dto == null) return null!;

            return new Category
            {
                Name = dto.Name
            };
        }

        // CategoryUpdateDto -> Mavjud Category entitysini yangilash
        public static void UpdateEntity(this CategoryUpdateDto dto, Category existingCategory)
        {
            if (dto == null || existingCategory == null) return;

            existingCategory.Name = dto.Name;
        }
    }
}
