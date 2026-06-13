using Restaurant.Api.Dtos;
using Restaurant.Api.Repositories;

namespace Restaurant.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<CategoryResponseDto?> GetByIdAsync(long id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto)
    {
        return await _categoryRepository.AddAsync(dto);
    }

    public async Task<CategoryResponseDto?> UpdateAsync(long id, CategoryUpdateDto dto)
    {
        return await _categoryRepository.UpdateAsync(id, dto);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _categoryRepository.DeleteAsync(id);
    }
}
