using Fixxo_MVC_App.Models;
using Fixxo_MVC_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_MVC_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string sort)
        {
            IEnumerable<ProductModel> products;
    
            switch (sort)
            {
                case "featured":
                    products = await _productService.GetByTagAsync("featured");
                    break;
                case "new":
                    products = await _productService.GetByTagAsync("new");
                    break;
                case "popular":
                    products = await _productService.GetByTagAsync("popular");
                    break;
                default:
                    products = await _productService.GetAll();
                    break;
            }
    
            return View(products);
        }
        
    }
}