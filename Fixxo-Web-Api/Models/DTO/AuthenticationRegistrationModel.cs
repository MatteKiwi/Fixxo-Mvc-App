using System.ComponentModel.DataAnnotations;
using Fixxo_Web_Api.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Fixxo_Web_Api.Models.DTO;

public class AuthenticationRegistrationModel
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; } = null!;
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = null!;

    public static implicit operator IdentityUser(AuthenticationRegistrationModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
        };
    }

    public static implicit operator UserProfileEntity(AuthenticationRegistrationModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
        };
    }
}