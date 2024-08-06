using System.ComponentModel.DataAnnotations;
using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Web.Models;

public class AddEditFormsVm
{
    public int Id { get; set; }
    [Required(ErrorMessage = "campo obrigatório")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "campo obrigatório")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "campo obrigatório")]
    public StatusFormsVm? Status { get; set; }
}

public enum StatusFormsVm
{
    Active = 1,
    Inactive = 2
}

public static class Mappins
{
    public static AddEditFormsVm ToAddEditVm(this Form form) =>
        new ()
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
            Status = (StatusFormsVm)form.Status
        };
    
    public static Form ToData(this AddEditFormsVm model) =>
        new ()
        {
            Id = model.Id,
            Name = model.Name!,
            Description = model.Description!,
            Status = (StatusForm)model.Status!
        };
    
}