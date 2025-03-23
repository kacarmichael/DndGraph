using Dnd.Core.Auth.Models;
using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Models.Users;

public interface IDomainUser
{
    int Id { get; }
    int AuthUserId { get; }

    IAuthUser AuthUser { get; }
    string Username { get; }
    List<ICharacter> Characters { get; }
}