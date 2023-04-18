using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepo;

        public ProductsController(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepo.GetAllAsync());
        }
        
        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> GetByArticleNumber(string articleNumber)
        {
            var product = await _productRepo.GetByArticleNumberAsync(articleNumber);
            return Ok(product);
            
        }
        
        [HttpGet("tags/{tagName}")]
        public async Task<IActionResult> GetByTag(string tagName)
        {
            return Ok(await _productRepo.GetByTagAsync(tagName));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductHttpRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var product = await _productRepo.CreateAsync(request);
            return Created("", product);

        }
    
    }
}
