using MediatR;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Dtos.Courses;
using VirtualClassApp.Application.Features.Courses.Commands.CreateCourse;
using VirtualClassApp.Application.Features.Courses.Commands.UpdateCourse;
using VirtualClassApp.Application.Features.Courses.Queries.GetCourseById;
using VirtualClassApp.Application.Features.Courses.Queries.GetCourses;
using VirtualClassApp.WebAPI.EndpointsMappings.Abstractions;

namespace VirtualClassApp.WebAPI.EndpointsMappings.Courses;

public sealed class CoursesEndpointsMapper(string baseRoute) :
   EndpointsMapper(baseRoute)
{
    public override void MapEndpoints(WebApplication app)
    {
        app.MapPost(BaseRoute, async (CreateCourseRequest request, ISender sender) =>
        {
            await sender.Send(request);

            return Results.Ok();
        });

        app.MapPut(BaseRoute, async (UpdateCourseRequest request, ISender sender) =>
        {
            await sender.Send(request);

            return Results.Ok();
        });

        app.MapGet(BaseRoute, async (ISender sender, int pageNumber = 1, int pageSize = 10) =>
        {
            var request = new GetCoursesRequest((parameters) =>
            {
                parameters.SetPagination(new Pagination(pageNumber, pageSize));
                parameters.SetIsDeleted(false);
            });

            var response = await sender.Send(request);

            return Results.Ok(new CoursesPaginationResult
            {
                Items = response.Courses,
                TotalCount = response.Count,
                PageSize = pageSize,
                PageNumber = pageNumber
            });
        });

        app.MapGet(BaseRoute + "/deleted", async (ISender sender, int pageNumber = 1, int pageSize = 10) =>
        {
            var request = new GetCoursesRequest((parameters) =>
            {
                parameters.SetPagination(new Pagination(pageNumber, pageSize));
                parameters.SetIsDeleted(true);
            });

            var response = await sender.Send(request);

            return Results.Ok(new CoursesPaginationResult
            {
                Items = response.Courses,
                TotalCount = response.Count,
                PageSize = pageSize,
                PageNumber = pageNumber
            });
        });

        app.MapGet(BaseRoute + "/{id:guid}", async (ISender sender, Guid id) =>
        {
            var request = new GetCourseByIdRequest(id, false);

            var response = await sender.Send(request);

            return Results.Ok(response);
        });


        //app.MapGet(BaseRoute + "/{id:guid}/teachers", async (UserManager<ApplicationUser> userManager, Guid id) =>
        //{
        //    var teachers = await userManager.Users.AsNoTrackingWithIdentityResolution()
        //    .Where(x => x.TeacherTeachings.Any(x => x.Course.Id == id)).ToListAsync();

        //    var _teachers = teachers.Select(x => new
        //    {
        //        x.Id,
        //        x.UserName,
        //        x.Email
        //    }).ToList();

        //    return Results.Ok(_teachers);
        //});

        //app.MapGet(BaseRoute + "/{id:guid}/students", async (UserManager<ApplicationUser> userManager, Guid id) =>
        //{
        //    var students = await userManager.Users.AsNoTrackingWithIdentityResolution()
        //    .Where(x => x.StudentTeachings.Any(x => x.Course.Id == id)).ToListAsync();

        //    var _students = students.Select(x => new
        //    {
        //        x.Id,
        //        x.UserName,
        //        x.Email
        //    }).ToList();

        //    return Results.Ok(_students);
        //});
    }
}
