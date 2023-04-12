using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(/*awit _productRepo.GetAllAsync();*/);
        }
        
        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> GetByArticleNumber(string articleNumber)
        {
            /*var product = await _productRepo.GetByArticleNumberAsync(articleNumber);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product); */
            return Ok();
        }
        
        [HttpGet("tags/{tagName}")]
        public async Task<IActionResult> GetByTag(string tagName)
        {
            /*var products = await _productRepo.GetByTagAsync(tagName);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products); */
            return Ok();
        }
        
        [HttpGet("categories/{categoryName}")]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            /*var products = await _productRepo.GetByCategoryAsync(categoryName);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products); */
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(/*ProductHttpRequest product*/)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            /*var product = await _productRepo.CreateAsync(product);
            return Created("", product); */
            return Ok();
        }
    
    }
}
