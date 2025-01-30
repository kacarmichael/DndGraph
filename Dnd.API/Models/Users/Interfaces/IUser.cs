using Dnd.API.Models.Characters.Interfaces;

namespace Dnd.API.Models.Users.Interfaces;

public interface IUser
{
    string Username { get; }
    List<ICharacter> Characters { get; }
}