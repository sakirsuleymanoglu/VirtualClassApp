
using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Dtos.Courses;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;

public sealed class CreateCourseRequestHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCourseRequest, CreateCourseResponse>
{
    public async Task<CreateCourseResponse> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        await courseRepository.CreateAsync(new CreateCourseDto(new Course()
        {
            Title = request.Title,
            Description = request.Description,
            IsActive = request.IsActive,
        }, request.TeacherIds)
        , cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new();
    }
}