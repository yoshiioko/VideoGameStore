using VideoGameStore.Api.Authorization;
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

        group.MapGet("/", async (IGamesRepository repository) =>
        {
            return (await repository.GetAllAsync()).Select(game => game.AsDto());
        });

        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);

            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        })
        .WithName(GetGameEndpointName)
        .RequireAuthorization(Policies.ReadAccess);

        group.MapPost("/", async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate.ToUniversalTime(),
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        })
        .RequireAuthorization(Policies.WriteAccess);

        group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = await repository.GetAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate.ToUniversalTime();
            existingGame.ImageUri = updatedGameDto.ImageUri;

            await repository.UpdateAsync(existingGame);

            return Results.NoContent();
        })
        .RequireAuthorization(Policies.WriteAccess);

        group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);
            if (game is not null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        })
        .RequireAuthorization(Policies.WriteAccess);

        return group;
    }
}
