using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Web.Models;

public class FormProviderVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}

public static class Mapping
{
    public static FormProviderVm ToFormProviderVm(this Form form) => new FormProviderVm
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description
        };

}