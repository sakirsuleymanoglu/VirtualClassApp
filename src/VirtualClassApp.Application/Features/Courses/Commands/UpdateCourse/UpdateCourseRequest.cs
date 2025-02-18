using MediatR;

namespace VirtualClassApp.Application.Features.Courses.Commands.UpdateCourse;

public sealed record UpdateCourseRequest(
Guid Id,
string? Title = null,
string? Description = null,
List<Guid>? TeacherIds = null) : IRequest<UpdateCourseResponse>;


