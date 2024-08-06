using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Data.Repositories;

public class FormRepository(MetaFormsBuilderDbContext ctx) : GenericRepository<Form>(ctx), IFormRepository
{
    
}