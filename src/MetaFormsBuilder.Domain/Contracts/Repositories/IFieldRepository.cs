using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Domain.Contracts.Repositories;

public interface IFieldRepository : IGenericRepository<Field>
{
    Task<IEnumerable<Field>> GetByFormIdAsync(int formId, CancellationToken cancellationToken);
    Task<Field> GetWithAllDataAsync(int id, CancellationToken cancellationToken);
}