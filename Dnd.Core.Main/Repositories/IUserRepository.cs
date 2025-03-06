using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Main.Repositories;

public interface IUserRepository
{
    Task<IDomainUser> GetUserAsync(string username);
    Task<IDomainUser> AddUserAsync(IDomainUser domainUser);
    Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser);
    Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser);
    Task<IEnumerable<IDomainUser>> GetAllUsersAsync();
    Task<IDomainUser> GetUserByIdAsync(int id);
}