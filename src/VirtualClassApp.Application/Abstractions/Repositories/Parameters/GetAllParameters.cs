using System.Linq.Expressions;
using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Application.Abstractions.Repositories.Parameters;

public sealed class GetAllParameters<T> where T : class, IEntity, new()
{
    private Pagination? _pagination;

    private List<Filter<T>>? _filters;
    private List<OrderBy<T>>? _orderBies;

    public List<Filter<T>>? Filters => _filters;
    public Pagination? Pagination => _pagination;

    public List<OrderBy<T>>? OrderBies => _orderBies;

    public GetAllParameters<T> SetPagination(Pagination pagination)
    {
        _pagination = pagination;
        return this;
    }

    public GetAllParameters<T> AddFilter(Filter<T> filter)
    {
        _filters ??= [];
        _filters.Add(filter);
        return this;
    }

    public GetAllParameters<T> AddOrderBy(OrderBy<T> orderBy)
    {
        _orderBies ??= [];
        _orderBies.Add(orderBy);
        return this;
    }
}


public record Pagination(int Page, int Size);
public record Filter<T>(Expression<Func<T, bool>> Expression);

public record OrderBy<T>(Expression<Func<T, object>> Expression, bool isDescending = false);