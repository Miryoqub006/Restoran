using Restaurant.Api.Dtos;

namespace Restaurant.Api.Repositories;

public interface IFoodRepository
{
    Task<IEnumerable<FoodResponseDto>> GetAllAsync();
    Task<FoodResponseDto?> GetByIdAsync(long id);
    Task<FoodResponseDto> CreateAsync(FoodCreateDto foodDto);
    Task<FoodResponseDto?> UpdateAsync(long id, FoodUpdateDto foodDto);
    Task<bool> DeleteAsync(long id);
}


