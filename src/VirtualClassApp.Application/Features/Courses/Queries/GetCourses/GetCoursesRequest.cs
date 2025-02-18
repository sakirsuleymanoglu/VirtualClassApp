using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;

namespace VirtualClassApp.Application.Features.Courses.Queries.GetCourses;

public record GetCoursesRequest(Action<CoursesGetAllParameters>? GetAllParametersAction = null) : IRequest<GetCoursesResponse>;

