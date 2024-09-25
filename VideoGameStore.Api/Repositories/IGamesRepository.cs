using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Repositories;

public interface IGamesRepository
{
    IEnumerable<Game> GetAllAsync();
    Game? GetAsync(int id);
    void CreateAsync(Game game);
    void UpdateAsync(Game updatedGame);
    void DeleteAsync(int id);
}
