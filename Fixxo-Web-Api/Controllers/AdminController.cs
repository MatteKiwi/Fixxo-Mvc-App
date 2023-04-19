using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixxo_Web_Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [UseApiKey]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCheck()
        {
            return Ok();
        }
    }
}
