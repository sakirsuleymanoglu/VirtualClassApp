using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories;


namespace VirtualClassApp.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        //await userRepository.AddAsync(new()
        //{
        //    UserName = request.UserName,
        //    Email = request.Email,
        //}, request.Password, cancellationToken);

        //await unitOfWork.SaveChangesAsync(cancellationToken);

        //return new();

        return new();
    }
}