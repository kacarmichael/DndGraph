using Dnd.Application.Auth.Models;

namespace Dnd.Application.Auth.Repositories.Interfaces;

public interface IAuthUserRepository
{
    public Task<AuthUser> AddUserAsync(AuthUser user);
    public Task<AuthUser> GetUserAsync(string username);
    public Task<AuthUser> UpdateUserAsync(AuthUser user);
    public Task<Task> DeleteUserAsync(string username);
    public Task<IEnumerable<AuthUser>> GetAllUsersAsync();
}