namespace MetaFormsBuilder.Domain.Entities;

public class FieldSubmited : EntityBase
{
    public int FormSubmitedId { get; set; }
    public FormSubmited FormSubmited { get; set; } = null!;
    public int FieldId { get; set; }
    public Field Field { get; set; } = null!;
    public string? Value { get; set; }
}