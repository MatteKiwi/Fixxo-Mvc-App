using Fixxo_MVC_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetByTagAsync("featured");
            return View();
        }
        
    }
}