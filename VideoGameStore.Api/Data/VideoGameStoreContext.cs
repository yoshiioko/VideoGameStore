using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Data;

public class VideoGameStoreContext : DbContext
{
    public VideoGameStoreContext(DbContextOptions<VideoGameStoreContext> options) : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
