using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}