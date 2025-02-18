using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Dtos.Courses;

public record UpdateCourseDto(Course Course, List<Guid>? TeacherIds = null);