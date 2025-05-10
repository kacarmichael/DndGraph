using Dnd.Application.Auth.Models;
using Dnd.Application.Auth.Services.Interfaces;
using Dnd.Application.Main.Models.Users;
using Dnd.Application.Main.Services.Interfaces;

namespace Dnd.Application.Abstractions;

public class UserMapperService
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserMapperService(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public Task<AuthUser> MapToAuthUser(DomainUser user) => _authService.GetUserAsync(user.Username);

    public Task<DomainUser> MapToDomainUser(AuthUser user) => _userService.GetUserAsync(user.Username);
}