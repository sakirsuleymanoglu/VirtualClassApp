namespace VirtualClassApp.Application.Features.Courses.DTOs;

public class CreateCourse
{
    public CreateCourse()
    {
        TeacherIds = [];
    }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Guid> TeacherIds { get; set; }
}
