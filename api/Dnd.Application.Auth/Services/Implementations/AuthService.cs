using Dnd.Application.Auth.Models;
using Dnd.Application.Auth.Repositories.Interfaces;
using Dnd.Application.Auth.Services.Interfaces;

namespace Dnd.Application.Auth.Services.Implementations;

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

    public async Task<AuthUser> AddUserAsync(AuthUser user)
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

    public async Task<AuthUser> UpdateUserAsync(AuthUser user)
    {
        await _authUserRepository.UpdateUserAsync(user);
        return user;
    }

    public async Task<AuthUser> GetUserAsync(string username)
    {
        return await _authUserRepository.GetUserAsync(username);
    }
}