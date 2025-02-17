using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Models.Users.Interfaces;

public interface IDomainUser
{
    int Id { get; }
    string Username { get; }
    List<ICharacter> Characters { get; }
}