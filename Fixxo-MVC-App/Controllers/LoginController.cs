using Fixxo_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
           return RedirectToAction("Index", "Account");
        }
        

        return View(viewModel);
    }

}