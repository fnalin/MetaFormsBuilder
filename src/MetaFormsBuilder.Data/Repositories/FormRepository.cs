using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using MetaFormsBuilder.Domain.Exceptions.DomainExceptions;
using Microsoft.EntityFrameworkCore;

namespace MetaFormsBuilder.Data.Repositories;

public class FormRepository(MetaFormsBuilderDbContext ctx) : GenericRepository<Form>(ctx), IFormRepository
{
    private readonly MetaFormsBuilderDbContext _ctx = ctx;

    public async Task<Form> GetWithAllDataAsync(int id, CancellationToken cancellationToken)
    {
        var data = 
                    await _ctx.Forms
                                .Include(x=>x.Fields)
                                    .ThenInclude(x=>x.Fields)
                                .FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        return data ?? throw new NotFoundException("Form not found");
    }
}