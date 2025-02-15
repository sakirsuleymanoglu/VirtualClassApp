using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Application.Abstractions.Repositories.Courses;
using VirtualClassApp.Application.Abstractions.Repositories.Students;
using VirtualClassApp.Application.Abstractions.Repositories.Teachers;
using VirtualClassApp.Domain.Entities;
using VirtualClassApp.Persistence.Contexts;
using VirtualClassApp.Persistence.Interceptors;
using VirtualClassApp.Persistence.Repositories;
using VirtualClassApp.Persistence.Repositories.Courses;
using VirtualClassApp.Persistence.Repositories.Students;
using VirtualClassApp.Persistence.Repositories.Teachers;

namespace VirtualClassApp.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).AddInterceptors(new TimestampInterceptor()));

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 1;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
