using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaFormsBuilder.Data.Maps;

public class FormSubmitedMap: IEntityTypeConfiguration<FormSubmited>
{
    public void Configure(EntityTypeBuilder<FormSubmited> builder)
    {
        builder.ToTable(nameof(FormSubmited));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.User).IsRequired().HasMaxLength(100);
        
    }
}