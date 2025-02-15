using VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

namespace VirtualClassApp.WebAPI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app,
        params IEndpointsMapper[] endpointsMappers)
    {
        foreach (var item in endpointsMappers)
            item.MapEndpoints(app);

        return app;
    }
}
