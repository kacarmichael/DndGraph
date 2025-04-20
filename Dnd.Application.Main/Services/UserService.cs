using Dnd.Application.Main.Models.Users;
using Dnd.Core.Main.Models.Users;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;

namespace Dnd.Application.Main.Services;

public class UserService : IUserService
{
    private readonly IUserRepository<DomainUser> _repository;

    public UserService(IUserRepository<DomainUser> repository)
    {
        _repository = repository;
    }

    public async Task<IDomainUser> GetUserAsync(string username)
    {
        return await _repository.GetUserAsync(username);
    }

    public async Task<IDomainUser> GetUserByIdAsync(int userId)
    {
        return await _repository.GetUserByIdAsync(userId);
    }

    public async Task<IDomainUser> AddUserAsync(IDomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.AddUserAsync(userImpl);
    }

    public async Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.UpdateUserAsync(userImpl);
    }

    public async Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser)
    {
        var userImpl = domainUser as DomainUser;
        if (userImpl == null)
        {
            throw new ArgumentException("Invalid DomainUser in Creation");
        }

        return await _repository.DeleteUserAsync(userImpl);
    }

    public async Task<IEnumerable<IDomainUser>> GetAllUsersAsync() => await _repository.GetAllUsersAsync();
}