using VideoGameStore.Api.Data;
using VideoGameStore.Api.Endpoints;
using VideoGameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>(); // Only use this while testing with InMemGamesRepository!

var connString = builder.Configuration.GetConnectionString("DbContext");
builder.Services.AddNpgsql<VideoGameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
