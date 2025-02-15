using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Configurations;

public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(x => x.Teaching)
            .WithOne(x => x.Course).HasForeignKey<Course>(x => x.TeachingId);
    }
}
