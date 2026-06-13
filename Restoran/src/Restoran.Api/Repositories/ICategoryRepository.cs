namespace Restoran.Api.Repositories;

public interface ICategoryRepository
{
    public Task GetAllAsync();
    public Task<Dto> GetByIdAsync(long id);

    public Task<Dto> AddAsync(Dto category);

    public Task<long> UpdateAsync(Dto category);
    public Task DeleteAsync(long id);
    
}
