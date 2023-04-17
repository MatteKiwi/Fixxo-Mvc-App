namespace Fixxo_Web_Api.Models.DTO;

public class AuthenticationLoginModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}