using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Web.Models;

public class FormProviderVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<FieldFormProviderVm> Fields { get; set; } = new List<FieldFormProviderVm>();
}

public class FieldFormProviderVm
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int DataTypeId { get; set; }
    public int DisplayOrder { get; set; }
    public string? Html { get; set; }
    public bool IsRequired { get; set; }
    public int? FieldId { get; set; }
    public IEnumerable<FieldFormProviderVm>? Fields { get; set; } = null;
}

public static class Mapping
{
    public static FormProviderVm ToFormProviderVm(this Form form) => new FormProviderVm
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
            Fields = form.Fields.Select(x => x.ToFieldFormProviderVm())
        };
    
    private static FieldFormProviderVm ToFieldFormProviderVm(this Field field) => new FieldFormProviderVm
        {
            Id = field.Id,
            Name = field.Name,
            DataTypeId = field.DataTypeId,
            DisplayOrder = field.DisplayOrder,
            Html = field.Html,
            IsRequired = field.IsRequired,
            FieldId = field.FieldId,
            Fields = field.Fields.Select(x => x.ToFieldFormProviderVm())
        };

}