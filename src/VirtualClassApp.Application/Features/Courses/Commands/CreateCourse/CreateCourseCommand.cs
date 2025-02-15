using MediatR;

namespace VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;

public sealed record CreateCourseCommand(
    string Title,
    List<Guid> TeacherIds,
    string? Description = null,
    bool IsActive = true) : IRequest;
