using System.Security.Claims;
using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Models.Entities;
using Fixxo_Web_Api.Repositories;
using Fixxo_Web_Api.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fixxo_Web_Api.Services;

public class AuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleService _roleService;
    private readonly TokenGenerator _tokenGenerator;
    private readonly UserProfileRepository _userProfileRepository;

    public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleService roleService, TokenGenerator tokenGenerator, UserProfileRepository userProfileRepository)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleService = roleService;
        _tokenGenerator = tokenGenerator;
        _userProfileRepository = userProfileRepository;
    }

    public async Task<bool> RegisterAsync(AuthenticationRegistrationModel model)
    {
        try
        {
            await _roleService.CreateRoleAsync();
            if (!await _userManager.Users.AnyAsync())
            {
                model.Role = "admin";
            }
            else
            {
                model.Role = "productManager";
            }
            
            var identityResult = await _userManager.CreateAsync(model, model.Password);
            if (identityResult.Succeeded)
            {
                var identityUser = await _userManager.FindByEmailAsync(model.Email);
                if (identityUser != null) await _userManager.AddToRoleAsync(identityUser, model.Role);

                UserProfileEntity userProfile = model;
                userProfile.UserId = identityUser!.Id;

                await _userProfileRepository.AddAsync(userProfile);
                return true;
            }
        }
        catch {}
        return false;
    }

    public async Task<string> LoginAsync(AuthenticationLoginModel model)
    {
        var identityUser = await _userManager.FindByEmailAsync(model.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
            if (signInResult.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(identityUser);
                string roleName = role.FirstOrDefault();
                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim("role", roleName),
                    new Claim(ClaimTypes.Name, identityUser.Email!)
                });

                return _tokenGenerator.Generate(claims, DateTime.Now.AddHours(1));
            }
        }

        return string.Empty;
    }
}