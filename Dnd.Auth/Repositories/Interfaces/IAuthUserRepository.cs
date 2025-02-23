using Dnd.Auth.Models.Interfaces;

namespace Dnd.Auth.Repositories.Interfaces;

public interface IAuthUserRepository
{
    public Task<IAuthUser> AddUserAsync(IAuthUser user);
    public Task<IAuthUser> GetUserAsync(string username);
    public Task<IAuthUser> UpdateUserAsync(IAuthUser user);
    public Task<Task> DeleteUserAsync(string username);
    public Task<IEnumerable<IAuthUser>> GetAllUsersAsync();
}