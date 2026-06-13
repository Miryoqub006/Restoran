using Restoran.Api.Data;
using Restoran.Api.Entities;

namespace Restoran.Api.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Food>> GetAllAsync()
    {
        return await _context.Foods.ToListAsync();
    }

    public async Task<Food?> GetByIdAsync(long id)
    {
        return await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Food> CreateAsync(Food food)
    {
        await _context.Foods.AddAsync(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public async Task<Food> UpdateAsync(Food food)
    {
        _context.Foods.Update(food);
        await _context.SaveChangesAsync();
        return food;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var food = await GetByIdAsync(id);
        if (food is null) return false;

        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();
        return true;
    }
}
