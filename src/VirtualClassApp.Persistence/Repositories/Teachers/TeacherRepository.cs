using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Application.Abstractions.Repositories.Teachers;
using VirtualClassApp.Domain.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;

namespace VirtualClassApp.Persistence.Repositories.Teachers;

public sealed class TeacherRepository(ApplicationDbContext context) : Repository<Teacher>(context), ITeacherRepository
{
    protected override IQueryable<Teacher> Query => Table.AsNoTrackingWithIdentityResolution();

    public async override Task<GetAllResponse<Teacher>> GetAllAsync(Action<GetAllParameters<Teacher>>? parametersAction = null, CancellationToken cancellationToken = default)
    {
        List<Teacher> students;
        int count;
        var query = Query;

        if (parametersAction == null)
        {
            students = await query.ToListAsync(cancellationToken);
            count = await query.CountAsync(cancellationToken: cancellationToken);
        }
        else
        {
            GetAllParameters<Teacher> getAllParameters = new();

            parametersAction.Invoke(getAllParameters);

            query = GetAllByParameters(getAllParameters);

            students = await query.ToListAsync(cancellationToken);

            count = await CountAsync(getAllParameters.Filters, cancellationToken);
        }

        return new(students, count);
    }

    public override async Task<Teacher?> GetAsync(List<Filter<Teacher>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
