namespace VirtualClassApp.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddDefaultPolicy(policyBuilder =>
                                     policyBuilder.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials()
                                    .SetIsOriginAllowed(_ => true)));

        return services;
    }
}
