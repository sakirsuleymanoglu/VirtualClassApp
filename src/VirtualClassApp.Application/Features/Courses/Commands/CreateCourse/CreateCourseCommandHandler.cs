
using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;

namespace VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;

public sealed class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand>
{

    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        await courseRepository.GetAllAsync(parametersAction: (x) =>
        {
            x.SetPagination(new Pagination(1, 10));

        });
    }
}