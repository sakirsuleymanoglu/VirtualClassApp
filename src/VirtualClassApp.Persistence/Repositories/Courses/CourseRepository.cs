using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Domain.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;

namespace VirtualClassApp.Persistence.Repositories.Courses;

public sealed class CourseRepository(ApplicationDbContext context) : Repository<Course>(context), ICourseRepository
{
    protected override IQueryable<Course> Query => Table.AsNoTrackingWithIdentityResolution().Include(course => course.Teachers);

    public override async Task AddAsync(Course entity, CancellationToken cancellationToken = default)
    {
        HashSet<Teacher> teachers = [];

        foreach (var teacher in entity.Teachers)
        {
            teachers.Add(await Context.Teachers.SingleAsync(teacher => teacher.Id == teacher.Id, cancellationToken));
        }

        entity.Teachers = teachers;

        await Table.AddAsync(entity, cancellationToken);
    }

    public async override Task<GetAllResponse<Course>> GetAllAsync(Action<GetAllParameters<Course>>? parametersAction = null, CancellationToken cancellationToken = default)
    {
        var query = Query;
        List<Course> students;
        int count;


        if (parametersAction == null)
        {
            students = await query.ToListAsync(cancellationToken);
            count = await query.CountAsync(cancellationToken: cancellationToken);
        }
        else
        {
            GetAllParameters<Course> getAllParameters = new();

            parametersAction.Invoke(getAllParameters);

            query = GetAllByParameters(getAllParameters);

            students = await query.ToListAsync(cancellationToken);

            count = await CountAsync(getAllParameters.Filters, cancellationToken);
        }

        return new(students, count);
    }

    public override async Task<Course?> GetAsync(List<Filter<Course>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}