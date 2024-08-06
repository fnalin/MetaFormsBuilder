namespace MetaFormsBuilder.Domain.Entities;

public class Form : EntityBase
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public StatusForm Status { get; set; }

    public IEnumerable<Field> Fields { get; set; } = new List<Field>();
}

public enum StatusForm
{
    Active = 1,
    Inactive = 2,
    Deleted = 3
}