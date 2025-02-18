using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualClassApp.Persistence.Adapters;

namespace VirtualClassApp.Persistence.Configurations;

public sealed class CourseAdapterConfiguration : IEntityTypeConfiguration<CourseAdapter>
{
    public void Configure(EntityTypeBuilder<CourseAdapter> builder)
    {
        builder.HasOne(x => x.Teaching)
            .WithOne(x => x.Course).HasForeignKey<CourseAdapter>(x => x.TeachingId);
    }
}
