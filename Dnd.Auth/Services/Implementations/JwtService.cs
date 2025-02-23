using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dnd.Auth.Models.Implementations;
using Dnd.Auth.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dnd.Auth.Services.Implementations;

public class JwtService : IJwtService
{
    // private readonly string _secretKey;
    // private readonly string _issuer;
    // private readonly string _audience;
    private readonly JwtSettings _settings;

    // public JwtService(string secretKey, string issuer, string audience)
    // {
    //     Console.WriteLine($"Secret key: {secretKey}");
    //     Console.WriteLine($"Issuer: {issuer}");
    //     Console.WriteLine($"Audience: {audience}");
    //     _secretKey = secretKey;
    //     _issuer = issuer;
    //     _audience = audience;
    // }

    public JwtService(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public string GenerateToken(string username, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // var token = new JwtSecurityToken(_issuer, _audience, claims,
        //     expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
        var token = new JwtSecurityToken(_settings.Issuer, _settings.Audience, claims,
            expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}