using MetaFormsBuilder.Domain.Contracts.Infra;
using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetaFormsBuilder.Web.Controllers;

public class FormsController (IFormRepository formRepository, IUoW uow) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await formRepository.GetAsync(cancellationToken);
        return View(data);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddEdit(int id, CancellationToken cancellationToken)
    {
        var model = new AddEditFormsVm();

        if (id > 0)
        {
            var data = await formRepository.GetAsync(id, cancellationToken);
            model = data.ToAddEditVm();
        }

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEdit(int id, AddEditFormsVm model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var form = model.ToData();

        if (id == 0)
        {
            await formRepository.AddAsync(form, cancellationToken);
        }
        else
        {
            form.Id = id;
            await formRepository.UpdateAsync(form, cancellationToken);
        }

        await uow.CommitAsync(cancellationToken);
          
        return RedirectToAction("Index");
    }
    
    [HttpDelete]
    public async Task<IActionResult> Excluir(int id, CancellationToken cancelationToken)
    {

        var form = await formRepository.GetAsync(id, cancelationToken);
        await formRepository.DeleteAsync(form, cancelationToken);
        await uow.CommitAsync(cancelationToken);

        return NoContent();
    }
}