using MediatR;

namespace VirtualClassApp.Application.Features.Users.Commands.CreateUser;

public record CreateUserRequest(
    string UserName,
    string Email,
    string Password) : IRequest<CreateUserResponse>;
