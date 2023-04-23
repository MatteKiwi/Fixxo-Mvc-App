using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fixxo_Web_Api.Services;

public class RoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public async Task<bool> CreateRoleAsync()
    {
        if (!await _roleManager.Roles.AnyAsync())
        {
            var adminRole = new IdentityRole("admin");
            await _roleManager.CreateAsync(adminRole);
            var productManagerRole = new IdentityRole("productManager");
            await _roleManager.CreateAsync(productManagerRole);
            return false;
        }

        return true;
    }
}