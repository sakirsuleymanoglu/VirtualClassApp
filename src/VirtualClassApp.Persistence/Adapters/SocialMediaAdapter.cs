using VirtualClassApp.Domain.Entities;

namespace VirtualClassApp.Persistence.Adapters;

public sealed class SocialMediaAdapter : SocialMedia
{
    public ApplicationUser ApplicationUser { get; set; } = default!;
}