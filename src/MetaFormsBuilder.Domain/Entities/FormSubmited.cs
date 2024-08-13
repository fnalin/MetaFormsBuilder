namespace MetaFormsBuilder.Domain.Entities;

public class FormSubmited : EntityBase
{
    public int FormId { get; set; }
    public Form Form { get; set; }  = null!;
    public string User { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public IEnumerable<FieldSubmited> FieldSubmiteds { get; set; } = new List<FieldSubmited>();
}