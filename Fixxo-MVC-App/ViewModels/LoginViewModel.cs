using System.ComponentModel.DataAnnotations;

namespace Fixxo_MVC_App.ViewModels;

public class LoginViewModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;
    
    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}