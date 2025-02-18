using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Dtos.Courses;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseRequestHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCourseRequest, UpdateCourseResponse>
{
    public async Task<UpdateCourseResponse> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        await courseRepository.UpdateAsync(new UpdateCourseDto(new Course
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
        }, request.TeacherIds), cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new();
    }
}


