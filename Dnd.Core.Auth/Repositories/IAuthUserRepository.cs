using Dnd.Core.Auth.Models;

namespace Dnd.Core.Auth.Repositories;

public interface IAuthUserRepository
{
    public Task<IAuthUser> AddUserAsync(IAuthUser user);
    public Task<IAuthUser> GetUserAsync(string username);
    public Task<IAuthUser> UpdateUserAsync(IAuthUser user);
    public Task<Task> DeleteUserAsync(string username);
    public Task<IEnumerable<IAuthUser>> GetAllUsersAsync();
}