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

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _dbContext.Games.AsNoTracking()
                                     .ToArrayAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task CreateAsync(Game game)
    {
        _dbContext.Games.Add(game);
        _ = await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        _dbContext.Update(updatedGame);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _ = await _dbContext.Games.Where(game => game.Id == id)
                                  .ExecuteDeleteAsync();
    }
}
