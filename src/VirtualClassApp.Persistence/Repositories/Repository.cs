using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Domain.Abstractions.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;

namespace VirtualClassApp.Persistence.Repositories;
public abstract class Repository<T>(ApplicationDbContext context) : IRepository where T : class, IEntity, new()
{

    protected ApplicationDbContext Context => context;

    protected DbSet<T> Table => context.Set<T>();

    protected abstract IQueryable<T> Query { get; }



    //public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await Table.AddAsync(entity, cancellationToken);

    //public virtual void Delete(T entity) => Table.Remove(entity);
    //public virtual void Update(T entity) => Table.Update(entity);

    //public abstract Task<GetAllResponse<T>> GetAllAsync(Action<GetAllParameters<T>>? parametersAction = null, CancellationToken cancellationToken = default);

    //public abstract Task<T?> GetAsync(List<Filter<T>> filters, CancellationToken cancellationToken = default);

    //public async Task<bool> AnyAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    //{
    //    var query = Query;

    //    if (filters != null)
    //        query = query.Filters(filters);

    //    return await query.AnyAsync(cancellationToken);
    //}


    //public async Task<long> LongCountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    //{
    //    var query = Query;

    //    if (filters != null)
    //        query = query.Filters(filters);

    //    return await query.LongCountAsync(cancellationToken);
    //}

    protected async Task<int> CountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (filters != null)
            query = query.Filters(filters);

        return await query.CountAsync(cancellationToken);
        //}
    }

}
