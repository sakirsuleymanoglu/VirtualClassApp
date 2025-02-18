using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Application.Dtos.Courses;

namespace VirtualClassApp.Application.Abstractions.Repositories.Courses;

public interface ICourseRepository : IRepository
{
    Task CreateAsync(CreateCourseDto createCourseDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateCourseDto updateCourseDto, CancellationToken cancellationToken = default);
    Task<GetAllResponse<CourseDto>> GetAllAsync(Action<CoursesGetAllParameters>? getAllParametersAction = null, CancellationToken cancellationToken = default);
    Task<CourseDto?> GetByIdAsync(Guid id, bool? isDeleted = null, CancellationToken cancellationToken = default);
}

public class CoursesGetAllParameters : GetAllParameters
{

}
