namespace VirtualClassApp.Application.Dtos.ApplicationUsers;

public class ApplicationUserDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }

    public DateTime? CreatedDate { get; set; }
}
