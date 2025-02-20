namespace Dnd.Auth.Services.Interfaces;

public interface IAuthService
{
    public void AddUserAsync(string username, string password);
}