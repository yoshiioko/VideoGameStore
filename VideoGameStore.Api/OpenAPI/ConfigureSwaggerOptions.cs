using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VideoGameStore.Api.OpenAPI;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider providers;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider providers)
    {
        this.providers = providers;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in providers.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo()
                {
                    Title = $"Video Game Store API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "Manages the games catalog."
                }
            );
        }
    }
}
