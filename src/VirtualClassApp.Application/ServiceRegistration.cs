using Microsoft.Extensions.DependencyInjection;

namespace VirtualClassApp.Application;

public static class ServiceRegistration
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly
               (typeof(ServiceRegistration).Assembly);
        });

        return services;
    }
}
