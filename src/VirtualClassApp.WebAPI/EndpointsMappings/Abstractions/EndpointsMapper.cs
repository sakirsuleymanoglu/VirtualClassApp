
namespace VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

public abstract class EndpointsMapper(string baseRoute) : IEndpointsMapper
{
    protected string BaseRoute => baseRoute;
    public abstract void MapEndpoints(WebApplication app);
}
