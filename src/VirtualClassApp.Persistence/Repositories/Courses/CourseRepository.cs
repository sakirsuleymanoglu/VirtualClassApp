using Microsoft.EntityFrameworkCore;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Abstractions.Repositories.Parameters;
using VirtualClassApp.Application.Abstractions.Repositories.Responses;
using VirtualClassApp.Application.Dtos.Courses;
using VirtualClassApp.Persistence.Adapters;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Extensions;
using VirtualClassApp.Persistence.Mappings;

namespace VirtualClassApp.Persistence.Repositories.Courses;

public sealed class CourseRepository(ApplicationDbContext context) : Repository<CourseAdapter>(context), ICourseRepository
{
    protected override IQueryable<CourseAdapter> Query => Table.AsNoTrackingWithIdentityResolution().Include(course => course.Teaching.Teachers);

    //public override async Task AddAsync(Course entity, CancellationToken cancellationToken = default)
    //{
    //    //HashSet<ApplicationUser> teachers = [];

    //    //foreach (var teacher in entity.Teaching.Teachers)
    //    //{
    //    //    teachers.Add(await Context.Users.SingleAsync(teacher => teacher.Id == teacher.Id, cancellationToken));
    //    //}

    //    //entity.Teaching.Teachers = teachers;

    //    await Table.AddAsync(entity, cancellationToken);
    //}

    public async Task CreateAsync(CreateCourseDto createCourseDto, CancellationToken cancellationToken = default)
    {
        HashSet<ApplicationUser> teachers = [];

        foreach (var teacherId in createCourseDto.TeacherIds)
        {
            teachers.Add(await Context.Users.SingleAsync(teacher => teacher.Id == teacherId, cancellationToken));
        }

        await Table.AddAsync(new()
        {
            Title = createCourseDto.Course.Title,
            Description = createCourseDto.Course.Description,
            ImagePath = createCourseDto.Course.ImagePath,
            Teaching = new TeachingAdapter()
            {
                Teachers = teachers
            }
        }, cancellationToken);
    }

    public async Task<GetAllResponse<CourseDto>> GetAllAsync(Action<CoursesGetAllParameters>? getAllParametersAction = null, CancellationToken cancellationToken = default)
    {
        var query = Query;

        CoursesGetAllParameters getAllParameters = new();

        if (getAllParametersAction != null)
        {
            getAllParametersAction(getAllParameters);

            if (getAllParameters.Pagination != null)
                query = query.Pagination(getAllParameters.Pagination);

            if (getAllParameters.IsDeleted != null)
                query = query.Where(course => course.IsDeleted == getAllParameters.IsDeleted);

            if (getAllParameters.IsActive != null)
                query = query.Where(course => course.IsActive == getAllParameters.IsActive);

            if (getAllParameters.CreatedDate != null)
                query = query.Where(course => course.CreatedDate >= getAllParameters.CreatedDate.Start && course.CreatedDate <= getAllParameters.CreatedDate.End);
        }

        var items = await query.Select(course => CourseMapper.FromCourse(course)
        ).ToListAsync(cancellationToken: cancellationToken);

        var count = await GetCountAsync(getAllParameters, cancellationToken);

        return new(getAllParameters, items, count);
    }

    private async Task<int> GetCountAsync(CoursesGetAllParameters getAllParameters, CancellationToken cancellationToken)
    {
        var query = Query;

        if (getAllParameters.IsDeleted != null)
            query = query.Where(course => course.IsDeleted == getAllParameters.IsDeleted);

        if (getAllParameters.IsActive != null)
            query = query.Where(course => course.IsActive == getAllParameters.IsActive);

        if (getAllParameters.CreatedDate != null)
            query = query.Where(course => course.CreatedDate >= getAllParameters.CreatedDate.Start && course.CreatedDate <= getAllParameters.CreatedDate.End);

        return await query.CountAsync(cancellationToken: cancellationToken);
    }
    public async Task<CourseDto?> GetByIdAsync(Guid id,
        bool? isDeleted = null,
        CancellationToken cancellationToken = default)
    {
        var query = Query;

        if (isDeleted != null)
            query = query.Where(course => course.IsDeleted == isDeleted);

        CourseAdapter? course = await query.SingleOrDefaultAsync(course => course.Id == id, cancellationToken: cancellationToken);

        if (course == null) return null;

        return CourseMapper.FromCourse(course);
    }

    public async Task UpdateAsync(UpdateCourseDto updateCourseDto, CancellationToken cancellationToken = default)
    {
        HashSet<ApplicationUser> teachers = [];

        if (updateCourseDto.TeacherIds != null)
        {
            foreach (var teacherId in updateCourseDto.TeacherIds)
            {
                teachers.Add(await Context.Users.SingleAsync(teacher => teacher.Id == teacherId, cancellationToken));
            }
        }

        CourseAdapter course = await Table
            .Include(course => course.Teaching.Teachers)
            .SingleAsync(course => course.Id == updateCourseDto.Course.Id, cancellationToken: cancellationToken);

        if (updateCourseDto.TeacherIds != null)
            course.Teaching.Teachers = teachers;

        course.Title = updateCourseDto.Course.Title;
        course.Description = updateCourseDto.Course.Description;
        course.ImagePath = updateCourseDto.Course.ImagePath;
    }

    //public async override Task<GetAllResponse<Course>> GetAllAsync(Action<GetAllParameters<Course>>? parametersAction = null, CancellationToken cancellationToken = default)
    //{
    //    var query = Query;
    //    List<Course> students;
    //    int count;


    //    if (parametersAction == null)
    //    {
    //        students = await query.ToListAsync(cancellationToken);
    //        count = await query.CountAsync(cancellationToken: cancellationToken);
    //    }
    //    else
    //    {
    //        GetAllParameters<Course> getAllParameters = new();

    //        parametersAction.Invoke(getAllParameters);

    //        query = GetAllByParameters(getAllParameters);

    //        students = await query.ToListAsync(cancellationToken);

    //        count = await CountAsync(getAllParameters.Filters, cancellationToken);
    //    }

    //    return new(students, count);
    //}

    //public override async Task<Course?> GetAsync(List<Filter<Course>>? filters = null, CancellationToken cancellationToken = default)
    //{
    //    var query = Query;

    //    if (filters != null)
    //        query = query.Filters(filters);

    //    return await query.SingleOrDefaultAsync(cancellationToken);
    //}
}


