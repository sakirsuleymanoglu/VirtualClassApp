using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualClassApp.Persistence.Adapters;

namespace VirtualClassApp.Persistence.Configurations;

public sealed class TeachingAdapterConfiguration : IEntityTypeConfiguration<TeachingAdapter>
{
    public void Configure(EntityTypeBuilder<TeachingAdapter> builder)
    {
        builder.HasMany(x => x.Teachers).WithMany(x => x.TeacherTeachings)
            .UsingEntity(x => x.ToTable("TeacherTeaching"))
            ;
        builder.HasMany(x => x.Students).WithMany(x => x.StudentTeachings)
              .UsingEntity(x => x.ToTable("StudentTeaching"));
    }
}
