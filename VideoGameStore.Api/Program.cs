using VideoGameStore.Api.Authorization;
using VideoGameStore.Api.Data;
using VideoGameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddVideoGameStoreAuthorization();

var app = builder.Build();

await app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
