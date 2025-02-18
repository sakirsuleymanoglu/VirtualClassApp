using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Adapters;

public sealed class TeachingAdapter : Teaching
{
    public TeachingAdapter()
    {
        Teachers = [];
        Students = [];
    }

    public ICollection<ApplicationUser> Teachers { get; set; }
    public ICollection<ApplicationUser> Students { get; set; }
    public CourseAdapter Course { get; set; } = default!;
}
