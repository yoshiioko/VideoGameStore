using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace VideoGameStore.Api.Authorization;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddVideoGameStoreAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IClaimsTransformation, ScopeTransformation>()
                .AddAuthorization(options =>
        {
            options.AddPolicy(Policies.ReadAccess, builder =>
            builder.RequireClaim("scope", "games:read")
                   .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme, "Auth0")); // Enable using Auth0 schemes

            options.AddPolicy(Policies.WriteAccess, builder =>
            builder.RequireClaim("scope", "games:write")
                   .RequireRole("Admin")
                   .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme, "Auth0")); // Enable using Auth0 schemes);
        });

        return services;
    }
}
