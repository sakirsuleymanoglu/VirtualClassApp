using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Domain.Entities;

public sealed class Course : Entity
{
    public Course()
    {
        Teachers = [];
        Students = [];
    }

    public string? Title { get; set; }
    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}

