using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

[Authorize]
public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}