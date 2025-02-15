using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Domain.Entities;

public sealed class Teaching : Entity
{
    public Teaching()
    {
        Teachers = [];
        Students = [];
    }

    public ICollection<ApplicationUser> Teachers { get; set; }
    public ICollection<ApplicationUser> Students { get; set; }
    public Course Course { get; set; } = default!;
}