using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Students;
using VirtualClassApp.Application.Abstractions.Repositories.Teachers;
using VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;
using VirtualClassApp.Domain.Entities;
using VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

namespace VirtualClassApp.WebAPI.EndpointsMappings.Courses;

public sealed class CoursesEndpointsMapper(string baseRoute) :
   EndpointsMapper(baseRoute)
{
    public override void MapEndpoints(WebApplication app)
    {
        app.MapPost(BaseRoute, async (CreateCourseCommand request, ISender sender) =>
        {
            await sender.Send(request);

            return Results.Ok();
        });


        app.MapGet(BaseRoute, async (ICourseRepository courseRepository) =>
        {
            var courses = await courseRepository.GetAllAsync();

            var _courses = courses.Items.Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                x.IsActive,
                Teachers = x.Teachers.Select(t => new { t.Id, t.Name, t.Surname })
            });

            return Results.Ok(_courses);
        });

        app.MapGet($"{BaseRoute}/deleted", async (ICourseRepository courseRepository) =>
        {
            var courses = await courseRepository.GetAllAsync(x =>
            {
                x.AddFilter(new Filter<Course>(x => x.IsDeleted));
            });

            var _courses = courses.Items.Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                x.IsActive,
                Teachers = x.Teachers.Select(t => new { t.Id, t.Name, t.Surname })
            });

            return Results.Ok(_courses);
        });




        app.MapGet(BaseRoute + "/{id:guid}", async (ICourseRepository courseRepository, Guid id) =>
        {
            var course = await courseRepository.GetAsync(
            [
                new Filter<Course>(x => x.Id == id)
            ]);

            if (course == null)
            {
                return Results.NotFound();
            }

            var _course = new
            {
                course.Id,
                course.Title,
                course.Description,
                course.IsActive,
                Teachers = course.Teachers.Select(t => new { t.Id, t.Name, t.Surname })
            };


            return Results.Ok(_course);
        });


        app.MapGet(BaseRoute + "/{id:guid}/teachers", async (Guid id, ITeacherRepository teacherRepository) =>
        {
            var teachers = await teacherRepository.GetAllAsync(x =>
            {
                x.AddFilter(new Filter<Teacher>(x => x.Courses.Any(x => x.Id == id)));
            });

            var _teachers = teachers.Items.Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname
            }).ToList();

            return Results.Ok(_teachers);
        });

        app.MapGet(BaseRoute + "/{id:guid}/students", async (Guid id, IStudentRepository studentRepository) =>
        {
            var students = await studentRepository.GetAllAsync(x =>
            {
                x.AddFilter(new Filter<Student>(x => x.Courses.Any(x => x.Id == id)));
            });


            var _students = students.Items.Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname
            });

            return Results.Ok(_students);
        });
    }
}
