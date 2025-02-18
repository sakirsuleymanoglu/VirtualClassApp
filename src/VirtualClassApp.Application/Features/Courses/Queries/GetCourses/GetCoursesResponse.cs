using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Dtos.Courses;

namespace VirtualClassApp.Application.Features.Courses.Queries.GetCourses;

public record GetCoursesResponse(
    List<CourseDto> Courses,
    int Count
    );

