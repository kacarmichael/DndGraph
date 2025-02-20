namespace Dnd.Auth.Services.Interfaces;

public interface IJwtService
{
    public string GenerateToken(string username, string role) => "";
}