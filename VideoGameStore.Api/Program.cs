using VideoGameStore.Api.Endpoints;
using VideoGameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>(); // Only use this while testing with InMemGamesRepository!

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
