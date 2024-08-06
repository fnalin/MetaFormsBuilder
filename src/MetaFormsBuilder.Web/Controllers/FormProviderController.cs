using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetaFormsBuilder.Web.Controllers;

public class FormProviderController (IFormRepository formRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Submit(int id, CancellationToken cancellationToken)
    {
        var data = await formRepository.GetAsync(id, cancellationToken);
        var model = data.ToFormProviderVm();
        return View(model);
    }
}