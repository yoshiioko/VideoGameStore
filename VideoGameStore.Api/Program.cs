using Microsoft.AspNetCore.Cors.Infrastructure;
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
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsBuilder =>
    {
        var allowedOrigin = builder.Configuration["AllowedOrigin"] ?? throw new InvalidOperationException("AllowedOrigin is not set!");
        corsBuilder.WithOrigins(allowedOrigin)
                   .AllowAnyHeader()
                   .AllowAnyMethod();
    });
});

var app = builder.Build();

await app.Services.InitializeDb();
app.MapGamesEndpoints();
app.UseCors();

app.Run();
