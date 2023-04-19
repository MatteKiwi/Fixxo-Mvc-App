using System.Net;
using Fixxo_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");
            var response = await httpClient.PostAsJsonAsync("https://localhost:7084/api/Contacts", model);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        return View(model);
    }
}