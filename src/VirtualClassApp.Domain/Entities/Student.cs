namespace VirtualClassApp.Domain.Entities;

public sealed class Student : ApplicationUser
{
    public Student()
    {
        Courses = [];
    }

    public ICollection<Course> Courses { get; set; }
}
