using MediatR;


namespace VirtualClassApp.Application.Features.Users.Queries.GetUsers;

public sealed class GetUsersRequestHandler() : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        //var users = await userRepository.GetAllAsync(cancellationToken: cancellationToken);

        return new();
    }
}
