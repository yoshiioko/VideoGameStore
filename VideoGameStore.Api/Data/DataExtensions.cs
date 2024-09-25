using Microsoft.EntityFrameworkCore;
using VideoGameStore.Api.Repositories;

namespace VideoGameStore.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<VideoGameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DbContext");
        services.AddNpgsql<VideoGameStoreContext>(connString)
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

        return services;
    }
}
