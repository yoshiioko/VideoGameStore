using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Repositories;

public interface IGamesRepository
{
    void Create(Game game);
    void Delete(int id);
    Game? Get(int id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);
}
