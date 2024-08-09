using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaFormsBuilder.Data;

public sealed class MetaFormsBuilderDbContext: DbContext 
{

    public MetaFormsBuilderDbContext(DbContextOptions<MetaFormsBuilderDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Form> Forms => Set<Form>();
    public DbSet<Field> Fields => Set<Field>();
    public DbSet<DataType> DataTypes => Set<DataType>();
    public DbSet<FormSubmited> FormSubmiteds => Set<FormSubmited>();
    public DbSet<FieldSubmited> FieldSubmiteds => Set<FieldSubmited>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetaFormsBuilderDbContext).Assembly);
    }
}