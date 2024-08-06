namespace MetaFormsBuilder.Domain.Contracts.Infra;

public interface IUoW
{
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}