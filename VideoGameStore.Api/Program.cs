using VideoGameStore.Api.Authorization;
using VideoGameStore.Api.Data;
using VideoGameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddVideoGameStoreAuthorization();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

var app = builder.Build();

await app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
