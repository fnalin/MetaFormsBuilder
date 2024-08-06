using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Domain.Contracts.Repositories;

public interface IGenericRepository<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
    Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
    
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}