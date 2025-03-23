using Dnd.Core.Auth.Models;
using Dnd.Core.Main.Models.Users;

namespace Dnd.Core.Abstractions;

public interface IUserMapperService
{
    Task<IAuthUser> MapToAuthUser(IDomainUser user);
    Task<IDomainUser> MapToDomainUser(IAuthUser user);
}