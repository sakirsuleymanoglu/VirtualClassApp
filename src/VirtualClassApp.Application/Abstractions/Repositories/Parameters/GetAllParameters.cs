using System.Linq.Expressions;

namespace VirtualClassApp.Application.Abstractions.Repositories.Parameters;

public class GetAllParameters
{
    private Pagination? _pagination;
    private bool? _isActive;
    private bool? _isDeleted;

    public Pagination? Pagination => _pagination;
    public bool? IsActive => _isActive;
    public bool? IsDeleted => _isDeleted;

    public Date? CreatedDate => _createdDate;

    public Date? _createdDate;


    public GetAllParameters SetPagination(Pagination pagination)
    {
        _pagination = pagination;
        return this;
    }

    public GetAllParameters SetIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public GetAllParameters SetIsDeleted(bool isDeleted)
    {
        _isDeleted = isDeleted;
        return this;
    }

    public GetAllParameters SetCreatedDate(Date createdDate)
    {
        _createdDate = createdDate;
        return this;
    }
}


public record Pagination(int PageNumber, int PageSize);
public record Filter<T>(Expression<Func<T, bool>> Expression);

public record OrderBy<T>(Expression<Func<T, object>> Expression, bool IsDescending = false);


public record Date(DateTime Start, DateTime End);