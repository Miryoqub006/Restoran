using Restaurant.Api.Dtos;

namespace Restaurant.Api.Repositories;

public interface ICategoryRepository
{
    public Task<IEnumerable<CategoryResponseDto>> GetAllAsync();
    public Task<CategoryResponseDto?> GetByIdAsync(long id);

    public Task<CategoryResponseDto> AddAsync(CategoryCreateDto category);

    public Task<CategoryResponseDto?> UpdateAsync(long id, CategoryUpdateDto category);
    public Task<bool> DeleteAsync(long id);
}
