using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SetWhen.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SetWhen.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly string _key;

    public TokenService(IConfiguration config)
    {
        _key = config["Jwt:Key"] ?? "verylong_secure_secret_key_here_12345678!";
    }

    public string GenerateToken(Guid userId, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(6),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}