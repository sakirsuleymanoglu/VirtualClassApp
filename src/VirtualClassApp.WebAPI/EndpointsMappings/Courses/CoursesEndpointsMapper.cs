using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
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
                Teachers = x.Teaching.Teachers.Select(x => new
                {
                    x.Id,
                    x.UserName,
                    x.Email
                }).ToList()
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
                Teachers = x.Teaching.Teachers.Select(x => new
                {
                    x.Id,
                    x.UserName,
                    x.Email
                }).ToList()
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
                Teachers = course.Teaching.Teachers.Select(x => new
                {
                    x.Id,
                    x.UserName,
                    x.Email
                }).ToList()
            };


            return Results.Ok(_course);
        });


        app.MapGet(BaseRoute + "/{id:guid}/teachers", async (UserManager<ApplicationUser> userManager, Guid id) =>
        {
            var teachers = await userManager.Users.AsNoTrackingWithIdentityResolution()
            .Where(x => x.TeacherTeachings.Any(x => x.Course.Id == id)).ToListAsync();

            var _teachers = teachers.Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email
            }).ToList();

            return Results.Ok(_teachers);
        });


    }
}
