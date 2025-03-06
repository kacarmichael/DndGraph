using Dnd.Core.Main.Models.Characters;

namespace Dnd.Core.Main.Models.Users;

public interface IDomainUser
{
    int Id { get; }
    string Username { get; }
    List<ICharacter> Characters { get; }
}