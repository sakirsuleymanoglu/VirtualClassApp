using MediatR;

namespace VirtualClassApp.Application.Features.Users.Queries.GetUsers;

public sealed record GetUsersRequest : IRequest<GetUsersResponse>
{

}
