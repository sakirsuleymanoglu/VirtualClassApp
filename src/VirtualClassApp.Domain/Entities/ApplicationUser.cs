using Microsoft.AspNetCore.Identity;
using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>, IEntity
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid();
        SocialMedias = [];
        StudentTeachings = [];
        TeacherTeachings = [];
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Biography { get; set; }

    public string? AvatarPath { get; set; }
    public ICollection<SocialMedia> SocialMedias { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Teaching> StudentTeachings { get; set; }
    public ICollection<Teaching> TeacherTeachings { get; set; }
}
