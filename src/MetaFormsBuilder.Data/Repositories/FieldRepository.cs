using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using MetaFormsBuilder.Domain.Exceptions.DomainExceptions;
using Microsoft.EntityFrameworkCore;

namespace MetaFormsBuilder.Data.Repositories;

public class FieldRepository (MetaFormsBuilderDbContext ctx) : GenericRepository<Field>(ctx), IFieldRepository
{
    private readonly MetaFormsBuilderDbContext _ctx = ctx;

    public async Task<IEnumerable<Field>> GetByFormIdAsync(int formId, CancellationToken cancellationToken)
    {
        return await _ctx.Fields.Where(x => x.FormId == formId).Include(x=>x.DataType).ToListAsync(cancellationToken);
    }

    public async Task<Field> GetWithAllDataAsync(int id, CancellationToken cancellationToken)
    {
        var data = await _ctx.Fields.Include(x => x.DataType).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return data ?? throw new NotFoundException("Field not found");
    }
}