using Dnd.Roll.API.Models.Characters;

namespace Dnd.Roll.API.Services;

public interface ICharacterService
{
    IEnumerable<Character> GetAllCharacters();
    IEnumerable<Character> GetCurrentCharacters();
    Character GetCharacterDetails(int id);
}