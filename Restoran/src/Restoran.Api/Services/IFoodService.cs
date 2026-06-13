using Restaurant.Api.Dtos;

namespace Restaurant.Api.Services;

public interface IFoodService
{
    Task<IEnumerable<FoodDto>> GetAllAsync();
    Task<FoodDto?> GetByIdAsync(long id);
    Task<FoodDto> CreateAsync(FoodCreateDto dto);
    Task<FoodDto> UpdateAsync(long id, FoodUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}
