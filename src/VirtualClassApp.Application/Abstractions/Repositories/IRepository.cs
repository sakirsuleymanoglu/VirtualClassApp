using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Application.Abstractions.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    Task<GetAllResponse<T>> GetAllAsync(Action<GetAllParameters<T>>? parametersAction = null, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(List<Filter<T>> filters, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default);
    Task<int> CountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default);
    Task<long> LongCountAsync(List<Filter<T>>? filters = null, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}


