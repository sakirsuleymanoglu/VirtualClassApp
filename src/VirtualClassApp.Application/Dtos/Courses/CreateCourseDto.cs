using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Application.Dtos.Courses;

public record CreateCourseDto(Course Course, List<Guid> TeacherIds);
