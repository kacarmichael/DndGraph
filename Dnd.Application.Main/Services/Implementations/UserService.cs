using Dnd.Application.Main.Models.Users;
using Dnd.Application.Main.Repositories.Interfaces;
using Dnd.Application.Main.Services.Interfaces;

namespace Dnd.Application.Main.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository<DomainUser> _repository;

    public UserService(IUserRepository<DomainUser> repository)
    {
        _repository = repository;
    }

    public async Task<DomainUser> GetUserAsync(string username)
    {
        return await _repository.GetUserAsync(username);
    }

    public async Task<DomainUser> GetUserByIdAsync(int userId)
    {
        return await _repository.GetUserByIdAsync(userId);
    }

    public async Task<DomainUser> AddUserAsync(DomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.AddUserAsync(userImpl);
    }

    public async Task<DomainUser> UpdateUserAsync(DomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.UpdateUserAsync(userImpl);
    }

    public async Task<DomainUser> DeleteUserAsync(DomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.DeleteUserAsync(userImpl);
    }

    public async Task<IEnumerable<DomainUser>> GetAllUsersAsync() => await _repository.GetAllUsersAsync();
}