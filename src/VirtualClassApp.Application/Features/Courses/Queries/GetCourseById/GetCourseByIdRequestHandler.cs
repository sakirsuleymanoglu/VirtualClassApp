using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Dtos.Courses;

namespace VirtualClassApp.Application.Features.Courses.Queries.GetCourseById;

public sealed class GetCourseByIdRequestHandler(ICourseRepository courseRepository) : IRequestHandler<GetCourseByIdRequest, GetCourseByIdResponse>
{
    public async Task<GetCourseByIdResponse> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
    {
        CourseDto? course = await courseRepository.GetByIdAsync(request.Id,
              request.IsDeleted,
              cancellationToken: cancellationToken);

        return new(course);
    }
}