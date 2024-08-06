using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaFormsBuilder.Data.Repositories;

public class FieldRepository (MetaFormsBuilderDbContext ctx) : GenericRepository<Field>(ctx), IFieldRepository
{
    public async Task<IEnumerable<Field>> GetByFormIdAsync(int formId, CancellationToken cancellationToken)
    {
        return await ctx.Fields.Where(x => x.FormId == formId).Include(x=>x.DataType).ToListAsync(cancellationToken);
    }
}