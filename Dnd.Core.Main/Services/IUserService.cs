using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Main.Services;

public interface IUserService
{
    Task<IDomainUser> GetUserAsync(string username);
    Task<IDomainUser> GetUserByIdAsync(int userId);
    Task<IDomainUser> AddUserAsync(IDomainUser domainUser);
    Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser);
    Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser);

    Task<IEnumerable<IDomainUser>> GetAllUsersAsync();
}