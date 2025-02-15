using MediatR;

namespace VirtualClassApp.Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand(
    string UserName,
    string Email,
    string Password) : IRequest;
