using Dnd.Auth.Models.Implementations;
using Dnd.Auth.Models.Interfaces;
using Dnd.Auth.Repositories.Interfaces;
using Dnd.Auth.Services.Interfaces;

namespace Dnd.Auth.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IAuthUserRepository _authUserRepository;

    public AuthService(IAuthUserRepository authUserRepository)
    {
        _authUserRepository = authUserRepository;
    }

    public void AddUserAsync(string username, string password, string email, string role = "User")
    {
        _authUserRepository.AddUserAsync(
            new AuthUser(username, password, email, role));
    }

    public async Task<IAuthUser> AddUserAsync(IAuthUser user)
    {
        await _authUserRepository.AddUserAsync(user);
        return user;
    }

    public void ResetPasswordAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<Task> DeleteUserAsync(string username)
    {
        await _authUserRepository.DeleteUserAsync(username);
        return Task.CompletedTask;
    }

    public async Task<IAuthUser> UpdateUserAsync(IAuthUser user)
    {
        await _authUserRepository.UpdateUserAsync(user);
        return user;
    }
}