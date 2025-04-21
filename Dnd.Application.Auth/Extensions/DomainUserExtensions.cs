using Dnd.Application.Auth.Models;
using Dnd.Application.Main.Models.Users;

namespace Dnd.Application.Auth.Extensions;

public static class DomainUserExtensions
{
    public static DomainUser FromAuthUser(AuthUser authUser) => new DomainUser(authUser.Username);
}