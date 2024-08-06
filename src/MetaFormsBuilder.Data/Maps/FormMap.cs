using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaFormsBuilder.Data.Maps;

public class FormMap: IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.ToTable(nameof(Form));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(StatusForm.Active);

        builder.HasData(
            new Form() { Id = 1, Name = "Form 1", Description = "Description 1", Status = StatusForm.Active },
            new Form() { Id = 2, Name = "Form 2", Description = "Description 2", Status = StatusForm.Inactive },
            new Form() { Id = 3, Name = "Form 3", Description = "Description 3", Status = StatusForm.Active }
        );
    }
}