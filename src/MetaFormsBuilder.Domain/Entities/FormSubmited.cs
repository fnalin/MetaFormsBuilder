namespace MetaFormsBuilder.Domain.Entities;

public class FormSubmited : EntityBase
{
    public int FormId { get; set; }
    public string User { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public IEnumerable<FieldSubmited> FieldSubmiteds { get; set; } = new List<FieldSubmited>();
}