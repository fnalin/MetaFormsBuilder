using MetaFormsBuilder.Domain.Contracts.Infra;
using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using MetaFormsBuilder.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MetaFormsBuilder.Web.Controllers;

public class FieldsController (IFieldRepository fieldRepository, IDataTypeRepository dataTypeRepository, IUoW uow) : Controller
{
    
    public async Task<IActionResult> List([FromQuery]int formId, CancellationToken cancellationToken)
    {
        var data = await fieldRepository.GetByFormIdAsync(formId, cancellationToken);

        var model = data.ToVm(formId);
        
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddEdit(int id, [FromQuery] int formId,CancellationToken cancellationToken)
    {
        var dataTypes = await dataTypeRepository.GetAsync(cancellationToken);
        var enumerable = dataTypes as DataType[] ?? dataTypes.ToArray();
        var model = new FieldAddEditVm{ FormId = formId, DataTypes = enumerable.Select(x => new SelectListItem(x.Name, x.Id.ToString()))};

        if (id > 0)
        {
            var data = await fieldRepository.GetAsync(id, cancellationToken);
            model = data.ToAddEditVm(enumerable);
        }

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEdit(int id, FieldAddEditVm model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var field = model.ToData();

        if (id == 0)
        {
            await fieldRepository.AddAsync(field, cancellationToken);
        }
        else
        {
            field.Id = id;
            await fieldRepository.UpdateAsync(field, cancellationToken);
        }

        await uow.CommitAsync(cancellationToken);
          
        return RedirectToAction("List", new {formId = model.FormId});
    }
    
    [HttpPost]
    public async Task<IActionResult> Details(int fieldId, CancellationToken cancellationToken)
    {
        var field = await fieldRepository.GetAsync(fieldId, cancellationToken);
        return PartialView("_propertiesModal", field.ToVm());
    }
    
    [HttpDelete]
    public async Task<IActionResult> Excluir(int id, CancellationToken cancelationToken)
    {

        var form = await fieldRepository.GetAsync(id, cancelationToken);
        await fieldRepository.DeleteAsync(form, cancelationToken);
        await uow.CommitAsync(cancelationToken);

        return NoContent();
    }
    
    
}