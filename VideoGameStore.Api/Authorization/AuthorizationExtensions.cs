namespace VideoGameStore.Api.Authorization;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddVideoGameStoreAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.ReadAccess, builder => builder.RequireClaim("scope", "games:read"));

            options.AddPolicy(Policies.WriteAccess, builder => builder.RequireClaim("scope", "games:write")
                                                                      .RequireRole("Admin"));
        });

        return services;
    }
}
