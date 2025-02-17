using Dnd.API.Models.Users.Interfaces;

namespace Dnd.API.Services.Interfaces;

public interface IUserService
{
    Task<IDomainUser> GetUserAsync(string username);
    Task<IDomainUser> GetUserByIdAsync(int userId);
    Task<IDomainUser> AddUserAsync(IDomainUser domainUser);
    Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser);
    Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser);

    Task<IEnumerable<IDomainUser>> GetAllUsersAsync();
}