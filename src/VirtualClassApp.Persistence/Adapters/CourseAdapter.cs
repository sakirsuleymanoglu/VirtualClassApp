using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Adapters;

public sealed class CourseAdapter : Course
{
    public TeachingAdapter Teaching { get; set; } = default!;
}
