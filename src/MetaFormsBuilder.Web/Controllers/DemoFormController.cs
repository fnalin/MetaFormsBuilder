using Microsoft.AspNetCore.Mvc;

namespace MetaFormsBuilder.Web.Controllers;

public class DemoFormController : Controller
{
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}