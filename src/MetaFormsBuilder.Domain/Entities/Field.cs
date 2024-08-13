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
    public bool IsEmailAddress { get; set; }
    public bool IsPhone { get; set; }
    public bool IsUri { get; set; }
    
    //Extensões de arquivos permitidas
    public string? FileExtensionsAttribute { get; set; }
    
    //Qtde min de caracteres
    public int? MinStringLengthAttribute { get; set; }
    //Qtde max de caracteres
    public int? MaxStringLengthAttribute { get; set; }
    //min de valor
    public int? MinValueAttribute { get; set; }
    //max de valor
    public int? MaxValueAttribute { get; set; }
    //expressão regular
    public string? RegularExpressionAttribute { get; set; }
    
    public int? FieldId { get; set; }
    public Field? FieldItem { get; set; }
    public IEnumerable<Field> Fields { get; set; } = new List<Field>();

    public IEnumerable<FieldSubmited> FieldSubmiteds { get; set; } = new List<FieldSubmited>();
}