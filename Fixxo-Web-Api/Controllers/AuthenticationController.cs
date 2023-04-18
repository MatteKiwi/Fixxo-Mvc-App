using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AuthService _authService;

        public AuthenticationController(SignInManager<IdentityUser> signInManager, AuthService authService)
        {
            _signInManager = signInManager;
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(AuthenticationRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.RegisterAsync(model))
                {
                    return Created("", null);
                }
            }

            return BadRequest();
        }
        
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> SignIn(AuthenticationLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await _authService.LoginAsync(model);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(token);
                }
            }

            return Unauthorized("Invalid credentials");
        }
        
    }
}
