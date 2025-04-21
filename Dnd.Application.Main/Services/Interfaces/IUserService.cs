using Dnd.Application.Main.Models.Users;

namespace Dnd.Application.Main.Services.Interfaces;

public interface IUserService
{
    Task<DomainUser> GetUserAsync(string username);
    Task<DomainUser> GetUserByIdAsync(int userId);
    Task<DomainUser> AddUserAsync(DomainUser domainUser);
    Task<DomainUser> UpdateUserAsync(DomainUser domainUser);
    Task<DomainUser> DeleteUserAsync(DomainUser domainUser);

    Task<IEnumerable<DomainUser>> GetAllUsersAsync();
}