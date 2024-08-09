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
            new Field() { Id = 1, Name = "Personal Info", FormId = 1, DataTypeId = 1, Html = "<h3>Personal Info</h3>", DisplayOrder  = 0, IsRequired = false},
            new Field() { Id = 2, Name = "FirstName", FormId = 1, DataTypeId = 2, DisplayOrder  = 1, IsRequired = true},
            new Field() { Id = 3, Name = "LastName", FormId = 1, DataTypeId = 2, DisplayOrder  = 2, IsRequired = true},
            new Field() { Id = 4, Name = "BirthDate", FormId = 1, DataTypeId = 4, DisplayOrder  = 3, IsRequired = true},
            new Field() { Id = 5, Name = "Obs", FormId = 1, DataTypeId = 3, DisplayOrder  = 4, IsRequired = false}
        );
    }
}