using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaFormsBuilder.Data.Maps;

public class FieldMap: IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        builder.ToTable(nameof(Field));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        
        builder.HasOne<Form>(x=>x.Form).WithMany(x=>x.Fields).HasForeignKey(x=>x.FormId);
        builder.HasOne<DataType>(x=>x.DataType).WithMany(x=>x.Fields).HasForeignKey(x=>x.DataTypeId);
        

        builder.HasData(
            new Field() { Id = 1, Name = "Field 1", FormId = 1, DataTypeId = 1 },
            new Field() { Id = 2, Name = "Field 2", FormId = 1, DataTypeId = 2 },
            new Field() { Id = 3, Name = "Field 3", FormId = 2, DataTypeId = 3 }
        );
    }
}