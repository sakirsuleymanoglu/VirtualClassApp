using VirtualClassApp.Application.Dtos.ApplicationUsers;

namespace VirtualClassApp.Application.Dtos.Courses;

public record CourseDto
{
    public CourseDto()
    {
        Teachers = [];
    }

    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public List<ApplicationUserDto> Teachers { get; set; }

    public DateTime? CreatedDate { get; set; }
};
