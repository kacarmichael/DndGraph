using Dnd.Application.Main.Models.Users;
using Dnd.Core.Auth.Models;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Application.Main.Extensions;

public static class DomainUserExtensions
{
    public static IDomainUser FromAuthUser(IAuthUser authUser) => new DomainUser(authUser.Username);
}