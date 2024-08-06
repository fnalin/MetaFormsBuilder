namespace MetaFormsBuilder.Domain.Entities;

public class DataType : EntityBase
{
    public string Name { get; set; } = null!;
    public IEnumerable<Field> Fields { get; set; } = new List<Field>();

}