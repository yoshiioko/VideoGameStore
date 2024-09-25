using VideoGameStore.Api.Dtos;
using VideoGameStore.Api.Entities;
using VideoGameStore.Api.Repositories;

namespace VideoGameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
                          .WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) =>
        {
            return repository.GetAllAsync().Select(game => game.AsDto());
        });

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.GetAsync(id);

            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate.ToUniversalTime(),
                ImageUri = gameDto.ImageUri
            };

            repository.CreateAsync(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate.ToUniversalTime();
            existingGame.ImageUri = updatedGameDto.ImageUri;

            repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.GetAsync(id);
            if (game is not null)
            {
                repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}
