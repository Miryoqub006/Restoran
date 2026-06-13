using Restaurant.Api.Dtos;
using Restaurant.Api.Repositories;

namespace Restaurant.Api.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly ILogger<FoodService> _logger;

    public FoodService(IFoodRepository foodRepository, ILogger<FoodService> logger)
    {
        _foodRepository = foodRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<FoodResponseDto>> GetAllFoodsAsync()
    {
        _logger.LogInformation("Fetching all foods");

        var foods = (await _foodRepository.GetAllAsync()).ToList();

        _logger.LogInformation("Returned {Count} foods", foods.Count);
        return foods;
    }

    public async Task<FoodResponseDto?> GetFoodByIdAsync(long id)
    {
        var food = await _foodRepository.GetByIdAsync(id);
        if (food is null)
        {
            _logger.LogWarning("Food not found: Id={FoodId}", id);
            return null;
        }

        _logger.LogInformation("Food found: Id={FoodId}", id);
        return food;
    }

    public async Task<FoodResponseDto> CreateFoodAsync(FoodCreateDto dto)
    {
        try
        {
            var created = await _foodRepository.CreateAsync(dto);

            _logger.LogInformation(
                "Food created: Id={FoodId}, Name={FoodName}, Price={Price}",
                created.Id, created.Name, created.Price);

            return created;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating food: Name={FoodName}", dto.Name);
            throw;
        }
    }

    public async Task<bool> UpdateFoodAsync(long id, FoodUpdateDto dto)
    {
        var updated = await _foodRepository.UpdateAsync(id, dto);
        if (updated is null)
        {
            _logger.LogWarning("Food to update not found: Id={FoodId}", id);
            return false;
        }

        _logger.LogInformation("Food updated: Id={FoodId}", id);
        return true;
    }

    public async Task<bool> DeleteFoodAsync(long id)
    {
        var deleted = await _foodRepository.DeleteAsync(id);
        if (!deleted)
        {
            _logger.LogWarning("Food to delete not found: Id={FoodId}", id);
            return false;
        }

        _logger.LogInformation("Food deleted: Id={FoodId}", id);
        return true;
    }
}
