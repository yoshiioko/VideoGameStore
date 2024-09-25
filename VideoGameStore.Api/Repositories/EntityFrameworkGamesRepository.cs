using Microsoft.EntityFrameworkCore;
using VideoGameStore.Api.Data;
using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly VideoGameStoreContext dbContext;

    public EntityFrameworkGamesRepository(VideoGameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Game> GetAll()
    {
        return [.. dbContext.Games.AsNoTracking()];
    }

    public Game? Get(int id)
    {
        return dbContext.Games.Find(id);
    }

    public void Create(Game game)
    {
        dbContext.Games.Add(game);
        dbContext.SaveChanges();
    }

    public void Update(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _ = dbContext.Games.Where(game => game.Id == id)
                           .ExecuteDelete();
    }
}
