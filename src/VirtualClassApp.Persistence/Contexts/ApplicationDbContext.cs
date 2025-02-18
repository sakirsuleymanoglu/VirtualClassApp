using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualClassApp.Persistence.Adapters;

namespace VirtualClassApp.Persistence.Contexts;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<CourseAdapter> Courses { get; set; }

    public DbSet<SocialMediaAdapter> SocialMedias { get; set; }

    public DbSet<TeachingAdapter> Teachings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<Course>().HasQueryFilter(x => !x.IsDeleted);

        //builder.Entity<ApplicationUser>().HasQueryFilter(x => !x.IsDeleted);

        //builder.Entity<SocialMedia>().HasQueryFilter(x => !x.IsDeleted);


        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
