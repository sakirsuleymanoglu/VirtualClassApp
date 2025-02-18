using MediatR;

namespace VirtualClassApp.Application.Features.Courses.Queries.GetCourseById;

public record GetCourseByIdRequest(Guid Id, bool? IsDeleted = null) : IRequest<GetCourseByIdResponse>;
