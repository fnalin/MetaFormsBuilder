using MetaFormsBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetaFormsBuilder.Data.Maps;

public class FieldSubmitedMap: IEntityTypeConfiguration<FieldSubmited>
{
    public void Configure(EntityTypeBuilder<FieldSubmited> builder)
    {
        builder.ToTable(nameof(FieldSubmited));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Value).HasMaxLength(300);

        builder.HasOne(x => x.FormSubmited)
                    .WithMany(x => x.FieldSubmiteds)
                        .HasForeignKey(x => x.FormSubmitedId);
    }
}