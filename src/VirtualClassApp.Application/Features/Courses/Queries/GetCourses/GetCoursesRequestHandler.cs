using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;

namespace VirtualClassApp.Application.Features.Courses.Queries.GetCourses;

public sealed class GetCoursesRequestHandler(ICourseRepository courseRepository) : IRequestHandler<GetCoursesRequest, GetCoursesResponse>
{
    public async Task<GetCoursesResponse> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
    {
        var response = await courseRepository.GetAllAsync(request.GetAllParametersAction, cancellationToken);

        return new(response.Items, response.Count);
    }
}

