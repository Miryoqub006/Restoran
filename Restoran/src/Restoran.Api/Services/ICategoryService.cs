using Restaurant.Api.Dtos;

namespace Restaurant.Api.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
    Task<CategoryResponseDto?> GetByIdAsync(long id);
    Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto);
    Task<CategoryResponseDto?> UpdateAsync(long id, CategoryUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}
