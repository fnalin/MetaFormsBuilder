using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaFormsBuilder.Data.Maps;

public class DataTypeMap: IEntityTypeConfiguration<DataType>
{
    public void Configure(EntityTypeBuilder<DataType> builder)
    {
        builder.ToTable(nameof(DataType));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
       

        builder.HasData(
            new DataType() { Id = 1, Name = "Heading"},
            new DataType() { Id = 2, Name = "TextBox"},
            new DataType() { Id = 3, Name = "TextArea"},
            new DataType() { Id = 4, Name = "DatePicker"},
            new DataType() { Id = 5, Name = "DateTimePicker"},
            new DataType() { Id = 6, Name = "FileUpload"},
            new DataType() { Id = 7, Name = "CheckBox"},
            new DataType() { Id = 8, Name = "CheckBoxList"},
            new DataType() { Id = 9, Name = "RadioList"},
            new DataType() { Id = 10, Name = "Select"},
            new DataType() { Id = 11, Name = "Hidden"}
        );
    }
}