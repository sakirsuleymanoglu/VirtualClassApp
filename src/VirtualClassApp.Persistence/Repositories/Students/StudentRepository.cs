using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Application.Abstractions.Repositories.Students;
using VirtualClassApp.Domain.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;

namespace VirtualClassApp.Persistence.Repositories.Students;

public sealed class StudentRepository(ApplicationDbContext context) : Repository<Student>(context), IStudentRepository
{
    protected override IQueryable<Student> Query => Table.AsNoTrackingWithIdentityResolution();

    public async override Task<GetAllResponse<Student>> GetAllAsync(Action<GetAllParameters<Student>>? parametersAction = null, CancellationToken cancellationToken = default)
    {
        var query = Query;
        List<Student> students;
        int count;

        if (parametersAction == null)
        {
            students = await query.ToListAsync(cancellationToken);
            count = await query.CountAsync(cancellationToken: cancellationToken);
        }
        else
        {
            GetAllParameters<Student> getAllParameters = new();

            parametersAction.Invoke(getAllParameters);

            query = GetAllByParameters(getAllParameters);

            students = await query.ToListAsync(cancellationToken);

            count = await CountAsync(getAllParameters.Filters, cancellationToken);
        }

        return new(students, count);
    }

    public override async Task<Student?> GetAsync(List<Filter<Student>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}