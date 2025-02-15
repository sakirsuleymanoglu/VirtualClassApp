using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Domain.Abstractions.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;

namespace VirtualClassApp.Persistence.Repositories;
public abstract class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class, IEntity, new()
{
    protected DbSet<T> Table => context.Set<T>();

    protected abstract IQueryable<T> Query { get; }

    protected IQueryable<T> GetAllByParameters(GetAllParameters<T> getAllParameters)
    {
        var query = Query;

        if (getAllParameters.Pagination != null)
            query = query.Pagination(getAllParameters.Pagination);

        if (getAllParameters.Filters != null)
            query = query.Filters(getAllParameters.Filters);

        if (getAllParameters.OrderBies != null)
            query = query.OrderBies(getAllParameters.OrderBies);

        return query;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await Table.AddAsync(entity, cancellationToken);

    public void Delete(T entity) => Table.Remove(entity);
    public void Update(T entity) => Table.Update(entity);

    public abstract Task<GetAllResponse<T>> GetAllAsync(Action<GetAllParameters<T>>? parametersAction = null, CancellationToken cancellationToken = default);

    public abstract Task<T?> GetAsync(List<Filter<T>> filters, CancellationToken cancellationToken = default);

    public async Task<bool> AnyAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.AnyAsync(cancellationToken);
    }


    public async Task<long> LongCountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.LongCountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.CountAsync(cancellationToken);
    }
}
