using System.Security.Claims;
using Fixxo_Web_Api.Utils;
using Microsoft.AspNetCore.Identity;

namespace Fixxo_Web_Api.Services;

public class AuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    
    public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public async Task<string> SignInAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email!)
            });
            return TokenGenerator.GenerateJwtToken(claimsIdentity, DateTime.Now.AddHours(2), _configuration.GetValue<string>("SecretKey")!);
        }
        return null!;
    }
}