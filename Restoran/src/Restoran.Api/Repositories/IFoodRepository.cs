namespace Restoran.Api.Repositories;


public interface IFoodRepository
{
    Task<IEnumerable<Food>> GetAllAsync();
    Task<Food?> GetByIdAsync(long id);
    Task<Food> CreateAsync(Food food);
    Task<Food> UpdateAsync(Food food);
    Task<bool> DeleteAsync(long id);
}


