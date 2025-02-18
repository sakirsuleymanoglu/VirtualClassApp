using MediatR;

namespace VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;

public sealed record CreateCourseRequest(
    string Title,
    List<Guid> TeacherIds,
    string? Description = null,
    bool IsActive = true) : IRequest<CreateCourseResponse>;
