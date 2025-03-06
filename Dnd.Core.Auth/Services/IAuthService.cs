using Dnd.Core.Auth.Models;

namespace Dnd.Core.Auth.Services;

public interface IAuthService
{
    public void AddUserAsync(string username, string password, string email, string role);
    public Task<IAuthUser> AddUserAsync(IAuthUser user);
    public void ResetPasswordAsync(string username);

    public Task<Task> DeleteUserAsync(string username);
    public Task<IAuthUser> UpdateUserAsync(IAuthUser user);

    public Task<IAuthUser> GetUserAsync(string username);
}