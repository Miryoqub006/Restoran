using Microsoft.EntityFrameworkCore;
using Restaurant.Api.Data;
using Restaurant.Api.Dtos;
using Restaurant.Api.Entities;
using Restaurant.Api.Mappings;

namespace Restaurant.Api.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FoodResponseDto>> GetAllAsync()
    {
        var foods = await _context.Foods
            .Include(f => f.Category)
            .ToListAsync();
        return foods.Select(f => f.ToResponseDto());
    }

    public async Task<FoodResponseDto?> GetByIdAsync(long id)
    {
        var food = await _context.Foods
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == id);
        return food?.ToResponseDto();
    }

    public async Task<FoodResponseDto> CreateAsync(FoodCreateDto foodDto)
    {
        var food = foodDto.ToEntity();
        await _context.Foods.AddAsync(food);
        await _context.SaveChangesAsync();

        var createdFood = await _context.Foods
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == food.Id);

        return createdFood!.ToResponseDto();
    }

    public async Task<FoodResponseDto?> UpdateAsync(long id, FoodUpdateDto foodDto)
    {
        var food = await _context.Foods.FindAsync(id);
        if (food == null) return null;

        foodDto.UpdateEntity(food);
        await _context.SaveChangesAsync();

        var updatedFood = await _context.Foods
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.Id == food.Id);

        return updatedFood?.ToResponseDto();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var food = await _context.Foods.FindAsync(id);
        if (food == null) return false;

        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();
        return true;
    }
}
