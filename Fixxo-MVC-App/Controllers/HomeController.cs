using Fixxo_MVC_App.Services;
using Fixxo_MVC_App.ViewModels;
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
           // var products = await _productService.GetByTagAsync("featured");

            HomeViewModel homeViewModel = new HomeViewModel
            {
                FeaturedProducts = await _productService.GetByTagAsync("featured"),
                NewProducts = await _productService.GetByTagAsync("new"),
                PopularProducts = await _productService.GetByTagAsync("popular")
            };


            return View(homeViewModel);
        }
        
    }
}