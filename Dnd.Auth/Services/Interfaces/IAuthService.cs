using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.Services.Interfaces;

public interface IAuthService
{
    public void AddUserAsync(string username, string password, string email, string role);
    public Task<IAuthUser> AddUserAsync(IAuthUser user);
    public void ResetPasswordAsync(string username);

    public Task<Task> DeleteUserAsync(string username);
    public Task<IAuthUser> UpdateUserAsync(IAuthUser user);
}