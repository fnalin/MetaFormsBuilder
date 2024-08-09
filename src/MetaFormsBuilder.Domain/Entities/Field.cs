namespace MetaFormsBuilder.Domain.Entities;

public class Field : EntityBase
{
    public string Name { get; set; } = null!;
    public int FormId { get; set; }
    public Form Form { get; set; } = null!;
    public int DataTypeId { get; set; }
    public DataType DataType { get; set; } = null!;

    public int DisplayOrder { get; set; }
    
    public string? Html { get; set; }
    
    public bool IsRequired { get; set; }

    public IEnumerable<FieldSubmited> FieldSubmiteds { get; set; } = new List<FieldSubmited>();

}