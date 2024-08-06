using MetaFormsBuilder.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MetaFormsBuilder.Web.Models;


public class FieldListVm
{
    public int FormId { get; set; }
    public IEnumerable<FieldVm> Fields { get; set; } = null!;
}

public class FieldAddEditVm
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string Name { get; set; } = null!;
    public int DataTypeId { get; set; }
    public IEnumerable<SelectListItem>? DataTypes { get; set; }
    
}

public class FieldVm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string DataType { get; set; } = null!;
}

public class DataTypeVm
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class Mappings {
    
    public static Field ToData(this FieldAddEditVm vm) =>
        new Field
        {
            Id = vm.Id,
            FormId = vm.FormId,
            Name = vm.Name,
            DataTypeId = vm.DataTypeId
        };
    
    public static FieldListVm ToVm(this IEnumerable<Field> fields, int formId) => 
        new FieldListVm
        {
            FormId = formId,
            Fields = fields.Select(x => x.ToVm())
        };
    
    public static FieldAddEditVm ToAddEditVm(this Field field, IEnumerable<DataType> dt) =>
        new FieldAddEditVm
        {
            Id = field.Id,
            FormId = field.FormId,
            Name = field.Name,
            DataTypeId = field.DataTypeId,
            DataTypes = dt.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        };
    
    public static DataTypeVm ToVm(this DataType dt) =>
        new DataTypeVm
        {
            Id = dt.Id,
            Name = dt.Name
        };

    private static FieldVm ToVm(this Field field) => 
        new FieldVm
        {
            Id = field.Id,
            Name = field.Name,
            DataType = field.DataType.Name
        };
    
    
}