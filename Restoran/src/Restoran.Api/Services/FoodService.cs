using Restaurant.Api.Dtos;
using Restaurant.Api.Entities;
using Restoran.Api.Repositories;

namespace Restaurant.Api.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _repository;
    private readonly IMapper _mapper;

    public FoodService(IFoodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FoodDto>> GetAllAsync()
    {
        var foods = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<FoodDto>>(foods);
    }

    public async Task<FoodDto?> GetByIdAsync(long id)
    {
        var food = await _repository.GetByIdAsync(id);
        if (food is null) return null;
        return _mapper.Map<FoodDto>(food);
    }

    public async Task<FoodDto> CreateAsync(FoodCreateDto dto)
    {
        var food = _mapper.Map<Food>(dto);
        var created = await _repository.CreateAsync(food);
        return _mapper.Map<FoodDto>(created);
    }

    public async Task<FoodDto> UpdateAsync(long id, FoodUpdateDto dto)
    {
        var food = await _repository.GetByIdAsync(id);
        if (food is null) throw new Exception($"Food with id {id} not found.");

        _mapper.Map(dto, food);
        var updated = await _repository.UpdateAsync(food);
        return _mapper.Map<FoodDto>(updated);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}
