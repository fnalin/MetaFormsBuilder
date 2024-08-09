using MetaFormsBuilder.Domain.Contracts.Infra;
using MetaFormsBuilder.Domain.Contracts.Repositories;
using MetaFormsBuilder.Domain.Entities;
using MetaFormsBuilder.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetaFormsBuilder.Web.Controllers;

public class FormProviderController (
    IFormRepository formRepository, IFormSubmitedRepository formSubmitedRepository,
    IUoW uow) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Submit(int id, CancellationToken cancellationToken)
    {
        var data = await formRepository.GetWithAllDataAsync(id, cancellationToken);
        var model = data.ToFormProviderVm();
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Submit(IFormCollection form, CancellationToken cancellationToken)
    {
        string formId = form["FormId"]!;
        var id = int.Parse(formId);
        var data = await formRepository.GetWithAllDataAsync(id, cancellationToken);
        
        List<FieldSubmited> fields = new List<FieldSubmited>();
        form.Keys.ToList().ForEach(key =>
        {
            var field = data.Fields.FirstOrDefault(x=>x.Name.ToLower() == key.ToLower());

            if (field is not null)
            {
                fields.Add(new FieldSubmited
                {
                    FieldId = field.Id,
                    Value = form[key]
                });
            }
        });
        
        var random = new Random();
        var list = new List<string>{ "user 1","user 2","user 3","user 4"};
        int index = random.Next(list.Count);
        var user = list[index];
        
        var formSubmited = new FormSubmited
        {
            FormId = id, FieldSubmiteds = fields, User = user
        };

        // var json = System.Text.Json.JsonSerializer.Serialize(form);
        await formSubmitedRepository.AddAsync(formSubmited, cancellationToken);
        await uow.CommitAsync(cancellationToken);
        
        return RedirectToAction("Index", "Forms");
    }
    
    
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await formSubmitedRepository.GetAsync(cancellationToken);
        return View(data);
    }
}