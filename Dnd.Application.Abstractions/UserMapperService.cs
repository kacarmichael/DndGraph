using Dnd.Core.Abstractions;
using Dnd.Core.Auth.Models;
using Dnd.Core.Auth.Services;
using Dnd.Core.Main.Models.Users;
using Dnd.Core.Main.Services;

namespace Dnd.Application.Abstractions;

public class UserMapperService : IUserMapperService
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserMapperService(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public Task<IAuthUser> MapToAuthUser(IDomainUser user) => _authService.GetUserAsync(user.Username);

    public Task<IDomainUser> MapToDomainUser(IAuthUser user) => _userService.GetUserAsync(user.Username);
}