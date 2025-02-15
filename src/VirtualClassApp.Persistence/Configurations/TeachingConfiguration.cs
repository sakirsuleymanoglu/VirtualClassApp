using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Configurations;

public sealed class TeachingConfiguration : IEntityTypeConfiguration<Teaching>
{
    public void Configure(EntityTypeBuilder<Teaching> builder)
    {
        builder.HasMany(x => x.Teachers).WithMany(x => x.TeacherTeachings)
            .UsingEntity(x => x.ToTable("TeacherTeaching"))
            ;
        builder.HasMany(x => x.Students).WithMany(x => x.StudentTeachings)
              .UsingEntity(x => x.ToTable("StudentTeaching"));
    }
}
