using Microsoft.EntityFrameworkCore;
using VideoGameStore.Api.Data;
using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly VideoGameStoreContext _dbContext;

    public EntityFrameworkGamesRepository(VideoGameStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Game> GetAllAsync()
    {
        return [.. _dbContext.Games.AsNoTracking()];
    }

    public Game? GetAsync(int id)
    {
        return _dbContext.Games.Find(id);
    }

    public void CreateAsync(Game game)
    {
        _dbContext.Games.Add(game);
        _dbContext.SaveChanges();
    }

    public void UpdateAsync(Game updatedGame)
    {
        _dbContext.Update(updatedGame);
        _dbContext.SaveChanges();
    }

    public void DeleteAsync(int id)
    {
        _ = _dbContext.Games.Where(game => game.Id == id)
                           .ExecuteDelete();
    }
}
