using Microsoft.AspNetCore.Identity;
using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Persistence;

public sealed class ApplicationRole : IdentityRole<Guid>, IEntity
{
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsActive { get; set; }
}