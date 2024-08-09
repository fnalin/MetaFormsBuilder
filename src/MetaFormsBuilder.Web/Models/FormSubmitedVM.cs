using MetaFormsBuilder.Domain.Entities;

namespace MetaFormsBuilder.Web.Models;

public class ListFormSubmitedVm
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int Count { get; set; }
}

public static class MappingExtensions
{
   
}