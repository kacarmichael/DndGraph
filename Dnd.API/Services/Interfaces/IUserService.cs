using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Services.Interfaces;

public interface IUserService
{
    Task<IUser> GetUserAsync(string username);
    Task<IUser> GetUserByIdAsync(int userId);
    Task<IUser> AddUserAsync(IUser user);
    Task<IUser> UpdateUserAsync(IUser user);
    Task<IUser> DeleteUserAsync(IUser user);

    Task<IEnumerable<IUser>> GetAllUsersAsync();
}