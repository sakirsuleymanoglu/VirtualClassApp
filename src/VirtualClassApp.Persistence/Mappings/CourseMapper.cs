using VirtualClassApp.Application.Dtos.Courses;
using VirtualClassApp.Persistence.Adapters;

namespace VirtualClassApp.Persistence.Mappings;

public static class CourseMapper
{
    public static CourseDto FromCourse(CourseAdapter course) => new()
    {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        Teachers = [.. course.Teaching.Teachers.Select(ApplicationUserMapper.FromApplicationUser)],
        CreatedDate = course.CreatedDate
    };
}
