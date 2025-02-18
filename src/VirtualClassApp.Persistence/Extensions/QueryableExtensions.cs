using VirtualClassApp.Application.Abstractions.Repositories.Parameters;

namespace VirtualClassApp.Persistence.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, Pagination pagination) where T : class => query.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);

    public static IQueryable<T> Filters<T>(this IQueryable<T> query, List<Filter<T>> filters) where T : class
    {
        foreach (var filter in filters)
            query = query.Where(filter.Expression);
        return query;
    }

    public static IQueryable<T> OrderBies<T>(this IQueryable<T> query, List<OrderBy<T>> orderBies)
    {

        for (int i = 0; i < orderBies.Count; i++)
        {
            if (i == 0)
            {
                if (!orderBies[i].IsDescending)
                {
                    query = query.OrderBy(orderBies[i].Expression);
                }
                else
                {
                    query = query.OrderByDescending(orderBies[i].Expression);
                }
            }
            else
            {
                if (!orderBies[i].IsDescending)
                {
                    query = ((IOrderedQueryable<T>)query).ThenBy(orderBies[i].Expression);
                }
                else
                {
                    query = ((IOrderedQueryable<T>)query).ThenByDescending(orderBies[i].Expression);
                }
            }
        }



        return query;
    }
}
