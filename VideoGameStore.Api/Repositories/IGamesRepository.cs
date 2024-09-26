using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Repositories;

public interface IGamesRepository
{
    Task<IEnumerable<Game>> GetAllAsync(int pageNumber, int pageSize);
    Task<Game?> GetAsync(int id);
    Task CreateAsync(Game game);
    Task UpdateAsync(Game updatedGame);
    Task DeleteAsync(int id);
    Task<int> CountAsync();
}
