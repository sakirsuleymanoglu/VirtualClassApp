namespace VirtualClassApp.Domain.Abstractions.Entities;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
}
