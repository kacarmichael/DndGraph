using Dnd.API.Models.Users.Interfaces;
using Dnd.API.Repositories;
using Dnd.API.Repositories.Interfaces;
using Dnd.API.Services.Interfaces;

namespace Dnd.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IUser> GetUserAsync(string username) => _repository.GetUserAsync(username);

    public Task<IUser> GetUserByIdAsync(int userId) => _repository.GetUserByIdAsync(userId);

    public Task<IUser> AddUserAsync(IUser user) => _repository.AddUserAsync(user);

    public Task<IUser> UpdateUserAsync(IUser user) => _repository.UpdateUserAsync(user);

    public Task<IUser> DeleteUserAsync(IUser user) => _repository.DeleteUserAsync(user);

    public Task<IEnumerable<IUser>> GetAllUsersAsync() => _repository.GetAllUsersAsync();
}