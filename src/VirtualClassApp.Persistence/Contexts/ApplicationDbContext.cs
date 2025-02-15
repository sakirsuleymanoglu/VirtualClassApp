using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Contexts;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }


    public DbSet<Course> Courses { get; set; }
    
    public DbSet<SocialMedia> SocialMedias { get; set; }

    public DbSet<Teaching> Teachings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<Course>().HasQueryFilter(x => !x.IsDeleted);

        //builder.Entity<ApplicationUser>().HasQueryFilter(x => !x.IsDeleted);

        //builder.Entity<SocialMedia>().HasQueryFilter(x => !x.IsDeleted);


        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
