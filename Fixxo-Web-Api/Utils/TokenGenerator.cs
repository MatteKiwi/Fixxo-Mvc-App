using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Fixxo_Web_Api.Utils;

public class TokenGenerator
{
    private readonly IConfiguration _configuration;

    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Generate(ClaimsIdentity claimsIdentity, DateTime expiresAt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
            Audience = _configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
            Subject = claimsIdentity,
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)), SecurityAlgorithms.HmacSha512Signature)
        };

        return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
    }
}