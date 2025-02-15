using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Persistence.Interceptors;

public sealed class TimestampInterceptor : SaveChangesInterceptor
{
    private static void SetProperties(DbContext? dbContext)
    {
        var entries = dbContext?.ChangeTracker.Entries<IEntity>();

        if (entries != null)
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;

                        var isDeletedProperty = entry.Property(x => x.IsDeleted);

                        if (isDeletedProperty.IsModified)
                        {
                            if (!isDeletedProperty.CurrentValue)
                            {
                                entry.Entity.DeletedDate = null;
                            }
                            else
                            {
                                entry.Entity.DeletedDate = DateTime.Now;
                            }
                        }


                        break;
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }

    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        SetProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetProperties(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
}
