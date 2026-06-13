using Restaurant.Api.Dtos;
using Restaurant.Api.Repositories;

namespace Restaurant.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all categories");

        var categories = (await _categoryRepository.GetAllAsync()).ToList();

        _logger.LogInformation("Returned {Count} categories", categories.Count);
        return categories;
    }

    public async Task<CategoryResponseDto?> GetByIdAsync(long id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            _logger.LogWarning("Category not found: Id={CategoryId}", id);
            return null;
        }

        _logger.LogInformation("Category found: Id={CategoryId}", id);
        return category;
    }

    public async Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto)
    {
        try
        {
            var created = await _categoryRepository.AddAsync(dto);

            _logger.LogInformation(
                "Category created: Id={CategoryId}, Name={CategoryName}",
                created.Id, created.Name);

            return created;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating category: Name={CategoryName}", dto.Name);
            throw;
        }
    }

    public async Task<CategoryResponseDto?> UpdateAsync(long id, CategoryUpdateDto dto)
    {
        var updated = await _categoryRepository.UpdateAsync(id, dto);
        if (updated is null)
        {
            _logger.LogWarning("Category to update not found: Id={CategoryId}", id);
            return null;
        }

        _logger.LogInformation("Category updated: Id={CategoryId}", id);
        return updated;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var deleted = await _categoryRepository.DeleteAsync(id);
        if (!deleted)
        {
            _logger.LogWarning("Category to delete not found: Id={CategoryId}", id);
            return false;
        }

        _logger.LogInformation("Category deleted: Id={CategoryId}", id);
        return true;
    }
}
