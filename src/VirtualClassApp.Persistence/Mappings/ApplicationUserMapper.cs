using VirtualClassApp.Application.Dtos.ApplicationUsers;

namespace VirtualClassApp.Persistence.Mappings;

public static class ApplicationUserMapper
{
    public static ApplicationUserDto FromApplicationUser(ApplicationUser applicationUser) => new()
    {
        Id = applicationUser.Id,
        Name = applicationUser.Name,
        Surname = applicationUser.Surname,
        Email = applicationUser.Email,
        PhoneNumber = applicationUser.PhoneNumber,
        UserName = applicationUser.UserName,
        CreatedDate = applicationUser.CreatedDate
    };
}
