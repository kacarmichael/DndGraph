using Dnd.Core.Main.Models.Users;
using Dnd.Core.Main.Repositories;
using Dnd.Core.Main.Services;

namespace Dnd.Application.Main.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IDomainUser> GetUserAsync(string username) => _repository.GetUserAsync(username);

    public Task<IDomainUser> GetUserByIdAsync(int userId) => _repository.GetUserByIdAsync(userId);

    public Task<IDomainUser> AddUserAsync(IDomainUser domainUser) => _repository.AddUserAsync(domainUser);

    public Task<IDomainUser> UpdateUserAsync(IDomainUser domainUser) => _repository.UpdateUserAsync(domainUser);

    public Task<IDomainUser> DeleteUserAsync(IDomainUser domainUser) => _repository.DeleteUserAsync(domainUser);

    public Task<IEnumerable<IDomainUser>> GetAllUsersAsync() => _repository.GetAllUsersAsync();
}