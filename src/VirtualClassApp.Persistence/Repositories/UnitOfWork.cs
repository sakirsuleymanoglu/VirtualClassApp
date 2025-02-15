using VirtualClassApp.Application.Abstractions.Repositories;
using VirtualClassApp.Persistence.Contexts;

namespace VirtualClassApp.Persistence.Repositories;

public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);
}
