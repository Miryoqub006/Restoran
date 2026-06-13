using Restaurant.Api.Dtos;

namespace Restaurant.Api.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodResponseDto>> GetAllFoodsAsync();
        Task<FoodResponseDto?> GetFoodByIdAsync(long id);
        Task<FoodResponseDto> CreateFoodAsync(FoodCreateDto dto);
        Task<bool> UpdateFoodAsync(long id, FoodUpdateDto dto);
        Task<bool> DeleteFoodAsync(long id);

        
        Task<IEnumerable<FoodResponseDto>> GetFoodsByCategoryIdAsync(long categoryId);
        Task<IEnumerable<FoodResponseDto>> GetAvailableFoodsAsync();
        Task<IEnumerable<FoodResponseDto>> SearchFoodsByNameAsync(string name);
    }
}