namespace Dnd.Core.Auth.Services;

public interface IJwtService
{
    public string GenerateToken(string username, string role) => "";
}