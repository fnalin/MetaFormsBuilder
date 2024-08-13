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
        builder.Property(x => x.Html).HasMaxLength(500);
        builder.Property(x => x.FileExtensionsAttribute).HasMaxLength(255);
        builder.Property(x => x.RegularExpressionAttribute).HasMaxLength(255);
        
        builder.HasOne<Form>(x=>x.Form).WithMany(x=>x.Fields).HasForeignKey(x=>x.FormId);
        builder.HasOne<DataType>(x=>x.DataType).WithMany(x=>x.Fields).HasForeignKey(x=>x.DataTypeId);
        
        builder.HasMany<Field>(x=>x.Fields).WithOne(x=>x.FieldItem).HasForeignKey(x=>x.FieldId);
        

        builder.HasData(
            new Field() { Id = 1, Name = "Personal Info", FormId = 1, DataTypeId = 1, Html = "<h3>Personal Info</h3>", DisplayOrder  = 0, IsRequired = false},
            new Field() { Id = 2, Name = "FirstName", FormId = 1, DataTypeId = 2, DisplayOrder  = 1, IsRequired = true},
            new Field() { Id = 3, Name = "LastName", FormId = 1, DataTypeId = 2, DisplayOrder  = 2, IsRequired = true},
            new Field() { Id = 4, Name = "BirthDate", FormId = 1, DataTypeId = 4, DisplayOrder  = 3, IsRequired = true},
            new Field() { Id = 5, Name = "Obs", FormId = 1, DataTypeId = 3, DisplayOrder  = 10, IsRequired = false},
            new Field() { Id = 6, Name = "DateAndHourTest", FormId = 1, DataTypeId = 5, DisplayOrder  = 4, IsRequired = false},
            new Field() { Id = 7, Name = "File", FormId = 1, DataTypeId = 6, DisplayOrder  = 5, IsRequired = false},
            new Field() { Id = 8, Name = "Aproved", FormId = 1, DataTypeId = 7, DisplayOrder  = 6, IsRequired = false},
            new Field() { Id = 9, Name = "Fruits", FormId = 1, DataTypeId = 8, DisplayOrder  = 7, IsRequired = false},
            new Field() { Id = 10, Name = "Banana", FormId = 1, DataTypeId = 8, DisplayOrder  = 7, IsRequired = false, FieldId = 9},
            new Field() { Id = 11, Name = "Apple", FormId = 1, DataTypeId = 8, DisplayOrder  = 7, IsRequired = false, FieldId = 9},
            new Field() { Id = 12, Name = "Pinaple", FormId = 1, DataTypeId = 8, DisplayOrder  = 7, IsRequired = false, FieldId = 9}
           
        );
    }
}