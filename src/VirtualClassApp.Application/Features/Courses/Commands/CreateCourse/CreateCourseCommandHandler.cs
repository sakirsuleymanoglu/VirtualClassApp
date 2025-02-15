
using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;

public sealed class CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCourseCommand>
{
    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        await courseRepository.AddAsync(new Course
        {
            Title = request.Title,
            Description = request.Description,
            IsActive = request.IsActive,
            Teaching = new Teaching()
            {
                Teachers = [.. request.TeacherIds.Select(id => new ApplicationUser
                {
                    Id = id
                })]
            }
        }, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}