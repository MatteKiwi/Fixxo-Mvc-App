using System.Net;
using System.Net.Http.Headers;
using Fixxo_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");
        var token = HttpContext.Request.Cookies["accessToken"];
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = httpClient.GetAsync("https://localhost:7084/api/Admin").Result;
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return View();
        }

        ModelState.AddModelError("", "Invalid credentials" + response.StatusCode);

        return RedirectToAction("Index", "Account");
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(CreateProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");
            var token = HttpContext.Request.Cookies["accessToken"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.PostAsJsonAsync("https://localhost:7084/api/Products", model);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return View(model);
            }

            ModelState.AddModelError("", "Invalid credentials" + response.StatusCode);
        }
        return View(model);
    }
}