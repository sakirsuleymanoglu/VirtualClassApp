using MediatR;
using VirtualClassApp.Application.Features.Users.Commands.CreateUser;
using VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

namespace VirtualClassApp.WebAPI.EndpointsMappings.Courses;

public sealed class UsersEndpointsMapper(string baseRoute) : EndpointsMapper(baseRoute)
{
    public override void MapEndpoints(WebApplication app)
    {
        app.MapPost(BaseRoute, async (CreateUserCommand request, ISender sender) =>
        {
            await sender.Send(request);
            return Results.Ok();
        });
    }
}
