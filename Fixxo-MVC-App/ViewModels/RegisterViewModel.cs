using System.ComponentModel.DataAnnotations;

namespace Fixxo_MVC_App.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First Name is required")]
    [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z]+)*$", ErrorMessage = "First Name is invalid")]
    public string FirstName { get; set; } = null!;
    
    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last Name is required")]
    [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z]+)*$", ErrorMessage = "Last Name is invalid")]
    public string LastName { get; set; } = null!;
    
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is invalid")]
    public string Email { get; set; } = null!;
    
    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password is invalid")]
    public string Password { get; set; } = null!;
    
    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
}