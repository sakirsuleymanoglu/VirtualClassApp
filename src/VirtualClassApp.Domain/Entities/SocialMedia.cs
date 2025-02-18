using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Domain.Entities;

public class SocialMedia : Entity
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public Guid ApplicationUserId { get; set; }
}