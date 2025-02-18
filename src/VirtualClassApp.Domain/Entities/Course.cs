using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Domain.Entities;

public class Course : Entity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public Guid TeachingId { get; set; }
}

