using VideoGameStore.Api.Data;
using VideoGameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

await app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
