namespace Dnd.Application.Auth.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(string username, string role) => "";
}