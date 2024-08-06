using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using MetaFormsBuilder.Domain.Exceptions.DomainExceptions;
using Microsoft.EntityFrameworkCore;

namespace MetaFormsBuilder.Data.Repositories;

public abstract class GenericRepository<TEntity> (MetaFormsBuilderDbContext ctx) : IGenericRepository<TEntity> 
    where TEntity : EntityBase
{
    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
    {
        var data = await ctx.Set<TEntity>().ToListAsync(cancellationToken);
        return data;
    }

    public async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
    {
        var data = await ctx.Set<TEntity>().FindAsync(id, cancellationToken);
        
        if (data is null)
            throw new NotFoundException($"{typeof(TEntity).Name} not found");

        return data;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await ctx.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken) =>
        Task.FromResult(ctx.Set<TEntity>().Update(entity)); 
    

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)=>
        Task.FromResult(ctx.Set<TEntity>().Remove(entity)); 
}