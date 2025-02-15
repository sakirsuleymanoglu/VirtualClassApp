namespace VirtualClassApp.Domain.Entities;

public sealed class Teacher : ApplicationUser
{
    public Teacher()
    {
        Courses = [];
    }

    public ICollection<Course> Courses { get; set; }
}
