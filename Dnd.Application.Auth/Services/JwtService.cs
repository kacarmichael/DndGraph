using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Dnd.Application.Auth.Models;
using Dnd.Core.Auth.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dnd.Application.Auth.Services;

public class JwtService : IJwtService
{
    // private readonly string _secretKey;
    // private readonly string _issuer;
    // private readonly string _audience;
    private readonly JwtSettings _jwtSettings;
    private readonly JwksSettings _jwksSettings;

    // public JwtService(string secretKey, string issuer, string audience)
    // {
    //     Console.WriteLine($"Secret key: {secretKey}");
    //     Console.WriteLine($"Issuer: {issuer}");
    //     Console.WriteLine($"Audience: {audience}");
    //     _secretKey = secretKey;
    //     _issuer = issuer;
    //     _audience = audience;
    // }

    public JwtService(IOptions<JwtSettings> jwtSettings, IOptions<JwksSettings> jwksSettings)
    {
        _jwtSettings = jwtSettings.Value;
        _jwksSettings = jwksSettings.Value;
    }

    public string GenerateToken(string username, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            new Claim("kid", _jwksSettings.Kid),
            new Claim("iss", _jwtSettings.Issuer),
            new Claim("aud", _jwtSettings.Audience)
        };

        var key = new RsaSecurityKey(new RSAParameters
        {
            Modulus = Convert.FromBase64String(_jwksSettings.N),
            Exponent = BitConverter.GetBytes(int.Parse(_jwksSettings.E))
        });
        var creds = new SigningCredentials(key, _jwksSettings.Alg);

        // var token = new JwtSecurityToken(_issuer, _audience, claims,
        //     expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
        var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims,
            expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}