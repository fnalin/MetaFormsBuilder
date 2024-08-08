using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Domain.Contracts.Repositories;

public interface IFormRepository : IGenericRepository<Form>
{
    Task<Form> GetWithAllDataAsync(int id, CancellationToken cancellationToken);
}