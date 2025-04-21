using Dnd.Application.Auth.Models;

namespace Dnd.Application.Auth.Services.Interfaces;

public interface IAuthService
{
    public void AddUserAsync(string username, string password, string email, string role);
    public Task<AuthUser> AddUserAsync(AuthUser user);
    public void ResetPasswordAsync(string username);

    public Task<Task> DeleteUserAsync(string username);
    public Task<AuthUser> UpdateUserAsync(AuthUser user);

    public Task<AuthUser> GetUserAsync(string username);
}