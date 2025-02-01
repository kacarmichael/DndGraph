using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Repositories;

public interface IUserRepository
{
    Task<IUser> GetUserAsync(string username);
    Task<IUser> AddUserAsync(IUser user);
    Task<IUser> UpdateUserAsync(IUser user);
    Task<IUser> DeleteUserAsync(IUser user);
    Task<IEnumerable<IUser>> GetAllUsersAsync();
    Task<IUser> GetUserByIdAsync(int id);
}