using MediatR;
using Microsoft.AspNetCore.Identity;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await userManager.CreateAsync(new()
        {
            UserName = request.UserName,
            Email = request.Email,
        }, request.Password);
    }
}