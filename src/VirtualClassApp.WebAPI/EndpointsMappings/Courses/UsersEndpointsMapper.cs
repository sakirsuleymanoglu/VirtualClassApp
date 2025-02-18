using MediatR;
using VirtualClassApp.Application.Features.Users.Commands.CreateUser;
using VirtualClassApp.Application.Features.Users.Queries.GetUsers;
using VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

namespace VirtualClassApp.WebAPI.EndpointsMappings.Courses;

public sealed class UsersEndpointsMapper(string baseRoute) : EndpointsMapper(baseRoute)
{
    public override void MapEndpoints(WebApplication app)
    {
        app.MapPost(BaseRoute, async (CreateUserRequest request, ISender sender) =>
        {
            await sender.Send(request);
            return Results.Ok();
        });


        app.MapGet(BaseRoute, async (ISender sender) =>
        {
            var request = new GetUsersRequest();
            var response = await sender.Send(request);
            return Results.Ok();
        });
    }
}
