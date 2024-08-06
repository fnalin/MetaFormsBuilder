using MetaFormsBuilder.Domain.Contracts.Infra;

namespace MetaFormsBuilder.Data.Data;

public class UoW (MetaFormsBuilderDbContext ctx) : IUoW
{
    public Task CommitAsync(CancellationToken cancellationToken) => ctx.SaveChangesAsync(cancellationToken);

    public Task RollbackAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}