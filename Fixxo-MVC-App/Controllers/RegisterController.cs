using Fixxo_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(RegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Account");
        }
        
        return View(viewModel);
    }
}