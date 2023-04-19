using System.Net.Http.Headers;
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
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

            var response = await httpClient.PostAsJsonAsync("https://localhost:7084/api/Authentication/Login", viewModel);
            var token = await response.Content.ReadAsStringAsync();

            HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.Now.AddHours(1)
            });

            return RedirectToAction("Index", "Account");
        }

        ModelState.AddModelError("", "Invalid credentials");

        return View(viewModel);

    }
}