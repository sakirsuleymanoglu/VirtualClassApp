using Microsoft.AspNetCore.Identity;
using VirtualClassApp.Persistence.Adapters;

namespace VirtualClassApp.Persistence;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {

        SocialMedias = [];
        StudentTeachings = [];
        TeacherTeachings = [];
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Biography { get; set; }

    public string? AvatarPath { get; set; }
    public ICollection<SocialMediaAdapter> SocialMedias { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public ICollection<TeachingAdapter> StudentTeachings { get; set; }
    public ICollection<TeachingAdapter> TeacherTeachings { get; set; }
}
