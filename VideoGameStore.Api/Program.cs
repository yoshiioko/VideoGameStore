using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using VideoGameStore.Api.Authorization;
using VideoGameStore.Api.Cors;
using VideoGameStore.Api.Data;
using VideoGameStore.Api.Endpoints;
using VideoGameStore.Api.OpenAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication()
                .AddJwtBearer() // Default scheme using local tool for tokens
                .AddJwtBearer("Auth0"); // Enable Auth0

builder.Services.AddVideoGameStoreAuthorization();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
})
.AddApiExplorer(options => options.GroupNameFormat = "'v'VVV");

builder.Services.AddVideoGameStoreCors(builder.Configuration);

builder.Services.AddSwaggerGen()
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddEndpointsApiExplorer();

var app = builder.Build();

await app.Services.InitializeDb();
app.MapGamesEndpoints();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.Run();
